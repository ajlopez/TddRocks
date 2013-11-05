
asyncTest('get work orders', function () {
    client.getWorkOrders(function (err, data) {
        equal(err, null);
        ok(data);
        ok(data.length);
        start();
    });
});

asyncTest('get work order', function () {
    client.getWorkOrder(1, function (err, data) {
        equal(err, null);
        ok(data);
        ok(data.id);
        equal(data.id, 1);
        ok(data.name);
        start();
    });
});

asyncTest('create work order', function () {
    client.createWorkOrder('A New Work Order',
        function (err, id) {
            equal(err, null);
            ok(id);
            client.getWorkOrder(id, function (err, data) {
                equal(err, null);
                ok(data);
                equal(data.id, id);
                equal(data.name, 'A New Work Order');
                start();
            });
        });
});
