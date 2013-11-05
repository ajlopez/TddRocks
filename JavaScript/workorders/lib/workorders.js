
function Repository() {
    var maxid = 0;
    var items = [];
    
    this.add = function (name) {
        var wo = { id: ++maxid, name: name };
        items[wo.id] = wo;
        return wo;
    }
    
    this.getById = function (id) {
        if (items[id])
            return items[id];
            
        return null;
    }
    
    this.getAll = function () {
        var result = [];
        
        Object.keys(items).forEach(function (id) {
            result.push(items[id]);
        });
        
        return result;
    }
}

module.exports = {
    createRepository: function () { return new Repository(); }
};