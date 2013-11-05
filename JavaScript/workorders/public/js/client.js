
var client = (function() {
    function getWorkOrders(cb) {
        $.ajax('/api/workorder', {
            success: function (data) {
                cb(null, data);
                }
            });
    }

    function getWorkOrder(id, cb) {
        $.ajax('/api/workorder/' + id, {
            success: function (data) {
                cb(null, data);
                }
            });
    }

    function createWorkOrder(name, cb) {
        var msg = {
            name: name
        };
        
        $.ajax({
            url: '/api/workorder',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(msg),
            success: function (data) {
                cb(null, data.id);
            }
        });
    }
    
    return {
        getWorkOrders: getWorkOrders,
        getWorkOrder: getWorkOrder,
        createWorkOrder: createWorkOrder
    }
}());

