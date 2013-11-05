var express = require('express'),
    path = require('path'),
    workorders = require('./lib/workorders.js').createRepository();
    
workorders.add("First Workorder");
workorders.add("Second Workorder");
    
var app = express();

app.use(express.bodyParser());
app.use(app.router);
app.use(express.static(path.join(__dirname, 'public')));
 
app.get('/api/workorder', function(req, res) {
    res.send(workorders.getAll());
});

app.get('/api/workorder/:id', function(req, res) {
    var wo = workorders.getById(parseInt(req.params.id));
    res.send(wo);
});

app.post('/api/workorder', function (req, res) {
    var data = req.body;
    var wo = workorders.add(data.name);
    res.send({ id: wo.id });
});

var port = process.env.PORT || 3000;

app.listen(port);
console.log('Listening on port 3000...');