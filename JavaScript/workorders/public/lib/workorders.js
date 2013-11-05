
if (typeof dates == 'undefined')
    var dates = require('./dates');

var workorders = (function() {
	var maxwoid = 0;
    
    function copyObjectProperties(from, to) {
        for (var n in from)
            if (typeof from[n] !== 'function')
                to[n] = from[n];
    }
    
    function firstMatch(items, match) {
        for (var n in items) {
            var item = items[n];
            var result = true;
            
            for (var m in match)
                if (item[m] != match[m])
                    result = false;
                    
            if (result)
                return item;
        }
        
        return null;
    }
    
    function Store() {
        var items = {};
        
        this.putItem = function (item) {
            items[item.Id] = item;
        }
        
        this.getItem = function (id) {
            if (items[id])
                return items[id];
            
            return null;
        }
        
        this.getItems = function () {
            var result = [];
            
            for (var n in items)
                result.push(items[n]);
                
            return result;
        }
    }
    
    var store = new Store();
    
    function Pivot() {
    }
    
    Pivot.prototype.getNames = function () {
        var names = [];
        
        for (var n in this.TeamMembers)
            names.push(this.TeamMembers[n].Name);
            
        return names;
    }
    
    Pivot.prototype.getIterationValues = function () {
        var values = [];
        
        for (var n in this.TeamMembers) {
            var tm = this.TeamMembers[n];
            var data = tm.Data;
            var subvalues = [];
            
            for (var ni = 0; ni < this.Weeks.length; ni++) {
                var total = 0;
                
                for (var nd = 0; nd < 7; nd++) {
                    var position = ni * 7 + nd;
                    
                    if (data.Values[position] && data.Values[position].Value)
                        total += data.Values[position].Value;
                }
                
                subvalues[ni] = total;
            }
            
            values.push(subvalues);
        }
        
        return values;
    }

	function WorkOrder(casename, project, scenario, options)
	{
        options = options || {};
        
        if (!options.Id)
            this.Id = ++maxwoid;
            
		this.Case = casename;
		this.Project = project;
		this.Scenario = scenario;
			
		this.TeamMembers = [];
        this.Intentions = [];
        this.IterationOverrides = [];
        this.DayOverrides = [];
        this.Holidays = [];
		
		for (var n in options)
			this[n] = options[n];
	}
    
    WorkOrder.prototype.addHoliday = function (holiday, remote) {
        var entry = { DayName: holiday, Remote: remote };
        
        var match = firstMatch(this.Holidays, entry);
        
        if (match)
            return;
            
        this.Holidays.push(entry);
    };
    
    WorkOrder.prototype.removeHoliday = function (holiday, remote) {
        var entry = { DayName: holiday, Remote: remote };
        var match = firstMatch(this.Holidays, entry);
        if (!match)
            return;
        var position = this.Holidays.indexOf(match);
        this.Holidays.splice(position, 1);
    };
    
    WorkOrder.prototype.isHoliday = function (holiday, remote) {
        var match = firstMatch(this.Holidays, { DayName: holiday, Remote: remote });
        var result = match != null;
        
        return result;
    };

	WorkOrder.prototype.addTeamMember = function (name, product) {
		this.TeamMembers.push({ Name: name, Product: product });
	};
    
    WorkOrder.prototype.removeTeamMember = function (name, product) {
        var entry = { Name: name, Product: product };
        var match = firstMatch(this.TeamMembers, entry);
        if (!match)
            return;
        var position = this.TeamMembers.indexOf(match);
        this.TeamMembers.splice(position, 1);
    };

	WorkOrder.prototype.addIntention = function (name, hours, options) {
        var intention = { Name: name, Hours: hours };
        
        if (options)
            copyObjectProperties(options, intention);
                
        this.Intentions.push(intention);
	};
    
    WorkOrder.prototype.removeIntention = function (name, hours, options) {
        var intention = { Name: name, Hours: hours };
        
        if (options)
            copyObjectProperties(options, intention);
            
        var match = firstMatch(this.Intentions, intention);
        
        if (!match)
            return;
            
        var position = this.Intentions.indexOf(match);
        this.Intentions.splice(position, 1);
    };
    
    WorkOrder.prototype.addIterationOverride = function (name, iteration, hours, options) {
        var override = { Name: name, Iteration: iteration, Hours: hours };
   
        if (options)
            copyObjectProperties(options, override);
               
        this.IterationOverrides.push(override);
    };
    
    WorkOrder.prototype.removeIterationOverride = function (name, iteration, hours, options) {
        var override = { Name: name, Iteration: iteration, Hours: hours };
   
        if (options)
            copyObjectProperties(options, override);

        var match = firstMatch(this.IterationOverrides, override);
        
        if (!match)
            return;
            
        var position = this.IterationOverrides.indexOf(match);
        
        this.IterationOverrides.splice(position, 1);
    };
    
    WorkOrder.prototype.addDayOverride = function (name, day, hours, options) {
        var override = { Name: name, OccursOn: day, Hours: hours };
   
        if (options)
            copyObjectProperties(options, override);
               
        this.DayOverrides.push(override);
    };
    
    WorkOrder.prototype.removeDayOverride = function (name, day, hours, options) {
        var override = { Name: name, OccursOn: day, Hours: hours };
   
        if (options)
            copyObjectProperties(options, override);

        var match = firstMatch(this.DayOverrides, override);
        
        if (!match)
            return;
            
        var position = this.DayOverrides.indexOf(match);
        this.DayOverrides.splice(position, 1);
    };
	
	WorkOrder.prototype.toJson = function () {
		var json = {};
		
        copyObjectProperties(this, json);
				
		return json;
	};
    
    WorkOrder.prototype.getPivot = function () {
        var pivot = new Pivot();
        
        pivot.Weeks = [ ];
        
        var week = null;
        
        for (var ni = 0; ni < this.Iterations; ni++) {
            if (week)
                week = week.nextWeek();
            else
                week = dates.createWeek(this.StartsOn);
            
            pivot.Weeks.push(week);
        }
        
        pivot.TeamMembers = [ ];
        
        for (var n in this.TeamMembers) {
            var tm = this.TeamMembers[n];
            var match = firstMatch(pivot.TeamMembers, { Name: tm.Name });
            
            if (match)
                continue;
            
            var newtm = { Name: tm.Name, Product: tm.Product };
            
            pivot.TeamMembers.push(newtm);
        }
        
        for (var n in this.Intentions) {
            var intention = this.Intentions[n];
            var match = firstMatch(pivot.TeamMembers, { Name: intention.Name });
            
            if (match)
                continue;
                            
            var newtm = { Name: intention.Name, Remote: intention.Remote };
            
            pivot.TeamMembers.push(newtm);
        }
        
        for (var n in this.IterationOverrides) {
            var override = this.IterationOverrides[n];
            var match = firstMatch(pivot.TeamMembers, { Name: override.Name });
            
            if (match)
                continue;
                            
            var newtm = { Name: override.Name };
            
            pivot.TeamMembers.push(newtm);
        }
        
        for (var n in this.DayOverrides) {
            var override = this.DayOverrides[n];
            var match = firstMatch(pivot.TeamMembers, { Name: override.Name });
            
            if (match)
                continue;
                            
            var newtm = { Name: override.Name };
            
            pivot.TeamMembers.push(newtm);
        }
        
        for (var n in pivot.TeamMembers) {
            var newtm = pivot.TeamMembers[n];
            
            var week = null;
            var values = [];
            var hoursonsite = 0;
            var hoursremote = 0;
            var nonsite = 0;
            var nremote = 0;
            
            for (var m in this.Intentions) {
                var intention = this.Intentions[m];
                
                if (intention.Name !== newtm.Name)
                    continue;
                
                if (intention.Remote) {
                    hoursremote += intention.Hours;
                    nremote++;
                }
                else {
                    hoursonsite += intention.Hours;
                    nonsite++;
                }
            }
        
            for (var ni = 0; ni < this.Iterations; ni++) {
                week = pivot.Weeks[ni];
                    
                for (nd = 0; nd < 7; nd++) {
                    if (week.Days[nd].isWeekEnd() || week.DayNames[nd] < this.StartsOn) {
                        values.push({});
                        continue;
                    }
                    
                    var isholidayremote = this.isHoliday(week.DayNames[nd], true);
                    var isholidayonsite = this.isHoliday(week.DayNames[nd], false);
                    
                    if (isholidayremote && isholidayonsite) {
                        values.push({});
                        continue;
                    }
                    
                    if (isholidayremote && !nonsite) {
                        values.push({});
                        continue;
                    }
                    
                    if (isholidayonsite && !nremote) {
                        values.push({});
                        continue;
                    }
                    
                    var hours;
                    
                    if (isholidayonsite)
                        hours = hoursremote;
                    else if (isholidayremote)
                        hours = hoursonsite;
                    else
                        hours = hoursremote + hoursonsite;

                    values.push({ Value: hours });
                }
            }
            
            // Iteration Overrides
            
            for (var m in this.IterationOverrides) {
                var override = this.IterationOverrides[m];
                
                if (override.Name !== newtm.Name)
                    continue;
                    
                if (override.Iteration < 1 || override.Iteration > this.Iterations)
                    continue;
                    
                var week = pivot.Weeks[override.Iteration - 1];
                
                for (nd = 0; nd < 7; nd++) {
                    if (this.isHoliday(week.DayNames[nd], override.Remote))
                        continue;
                    
                    if (week.Days[nd].isWeekEnd() || week.DayNames[nd] < this.StartsOn)
                        continue;
                        
                    var position = (override.Iteration - 1) * 7 + nd;
                    
                    var value = values[position];
                    
                    if (!value.IterationValue)
                        value.IterationValue = override.Hours;
                    else
                        value.IterationValue += override.Hours;
                 }
            }
            
            // Day Overrides
            
            for (var m in this.DayOverrides) {
                var override = this.DayOverrides[m];
                
                if (override.Name !== newtm.Name)
                    continue;
                    
                if (override.OccursOn < this.StartsOn)
                    continue;
                    
                var position = -1;
                
                for (var ni = 0; ni < this.Iterations; ni++) {
                    var week = pivot.Weeks[ni];
                    var index = week.DayNames.indexOf(override.OccursOn);
                    
                    if (index < 0)
                        continue;
                        
                    var position = ni * 7 + index;
                    
                    var value = values[position];
                    
                    if (!value.DayValue)
                        value.DayValue = override.Hours;
                    else
                        value.DayValue += override.Hours;
                        
                    break;                    
                }
            }
            
            // Apply overrides
            
            for (var nv = 0; nv < values.length; nv++) {
                var value = values[nv];
                
                if (!value)
                    continue;
                    
                if (value.DayValue != null)
                    value.Value = value.DayValue;
                else if (value.IterationValue != null)
                    value.Value = value.IterationValue;
            }
            
            var total = 0;
            
            for (var nv = 0; nv < values.length; nv++)
                if (values[nv] && values[nv].Value)
                    total += values[nv].Value;
            
            newtm.Data = { Values: values, Total: total };
        }
        
        return pivot;
    };

	function createWorkOrder(casename, project, scenario, options) {
		var wo = new WorkOrder(casename, project, scenario, options);
		store.putItem(wo);
		return wo;
	}
	
	function getWorkOrderById(id) {
        return store.getItem(id);
	}
    
    function updateWorkOrder(wo) {
        var original = getWorkOrderById(wo.Id);
        copyObjectProperties(wo, original);
    }
    
    function fromJson(json) {
        return createWorkOrder(json.Case, json.Project, json.Scenario, json);
    }
	
	return {
		createWorkOrder: createWorkOrder,
		getWorkOrders: function () { return store.getItems(); },
		getWorkOrderById: getWorkOrderById,
        updateWorkOrder: updateWorkOrder,
        fromJson: fromJson
	}
})();

if (typeof module !== 'undefined' && module && module.exports)
	module.exports = workorders;
