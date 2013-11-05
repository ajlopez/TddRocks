
var workorders = require('../lib/workorders.js');

exports['add workorder'] = function (test) {
    var repo = workorders.createRepository();
    var wo = repo.add('My work order');
    
    test.ok(wo);
    test.equal(wo.id, 1);
    test.equal(wo.name, 'My work order');
};