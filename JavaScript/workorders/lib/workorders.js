
function Repository() {
    var maxid = 0;
    
    this.add = function (name) {
        var wo = { id: ++maxid, name: name };
        return wo;
    }
}

module.exports = {
    createRepository: function () { return new Repository(); }
};