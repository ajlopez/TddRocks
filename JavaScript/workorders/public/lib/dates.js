
var dates = (function() {
    function Week(text) {
        var day = createDay(text);
        var wday = day.getWeekDay();
        day = day.addDays(-wday);
        
        this.Days = [];
        this.DayNames = [];
        
        for (var k = 0; k < 7; k++) {
            var newday = day.addDays(k);
            this.Days.push(newday);
            this.DayNames.push(newday.asString());
        }
        
        this.nextWeek = function () {
            return new Week(day.addDays(7).asString());
        };
        
        this.getDescription = function () {
            return this.DayNames[0].substring(5, 10) + ' to ' + this.DayNames[6].substring(5, 10);
        };
    }

    function Day(text) {
        var date = toDate(text);
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var weekday = date.getDay();
        
        this.asString = function () {
            return asString(year, 4) + '-' + asString(month, 2) + '-' + asString(day, 2);
        };
        
        this.addDays = function (days) {
            var date = new Date(year, month - 1, day + days, 0, 0, 0, 0);
            var text = dateAsString(date);
            return new Day(text);
        };
        
        this.getWeekDay = function () {
            if (weekday == 0)
                return 6;
            return weekday - 1;
        };
        
        this.getDayAsString = function () {
            return asString(day, 2);
        };
        
        this.isWeekEnd = function () {
            return weekday == 0 || weekday == 6;
        };
    }

    function asString(number, positions) {
        var text = number.toString();
        
        while (text.length < positions)
            text = '0' + text;
            
        return text;
    }

    function dateAsString(date) {
        return asString(date.getFullYear(), 4) + '-' + asString(date.getMonth() + 1, 2) + '-' + asString(date.getDate());
    }

    function createDay(text) {
        return new Day(text);
    }

    function createWeek(text) {
        return new Week(text);
    }

    function toDate(text) {
        var separator;
        
        if (text.indexOf('-') > 0)
            separator = '-';
        else if (text.indexOf('/') > 0)
            separator = '/';
        else if (text.indexOf('.') > 0)
            separator = '.';
            
        var parts = text.split(separator);
        
        var year = parseInt(parts[0]);
        var month = parseInt(parts[1]);
        var day = parseInt(parts[2]);
        
        return new Date(year, month - 1, day, 0, 0, 0, 0);
    }
    
    return {
        toDate: toDate,
        createDay: createDay,
        createWeek: createWeek
    }
})();

if (typeof module !== 'undefined' && module && module.exports)
	module.exports = dates;
