
var workorders = require('../lib/workorders.js');

exports['add workorder'] = function (test) {
    var repo = workorders.createRepository();
    var wo = repo.add('My work order');
    
    test.ok(wo);
    test.equal(wo.id, 1);
    test.equal(wo.name, 'My work order');
};

exports['get by id'] = function (test) {
    var repo = workorders.createRepository();
    repo.add('My work order');
    
    var wo = repo.getById(1);
    
    test.ok(wo);
    test.equal(wo.id, 1);
    test.equal(wo.name, 'My work order');
};

exports['get unknown by id'] = function (test) {
    var repo = workorders.createRepository();
    
    var wo = repo.getById(1);
    
    test.strictEqual(wo, null);
};

exports['get all'] = function (test) {
    var repo = workorders.createRepository();
    repo.add("First workorder");
    repo.add("Second workorder");
    
    var all = repo.getAll();
    
    test.ok(all);
    test.ok(Array.isArray(all));
    test.equal(all.length, 2);
    test.equal(all[0].id, 1);
    test.equal(all[0].name, "First workorder");
    test.equal(all[1].id, 2);
    test.equal(all[1].name, "Second workorder");
};