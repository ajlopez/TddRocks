
var test = require('./test'),
    path = require('path'),
    fs = require('fs');

function isFile(filename)
{
    try {
        var stats = fs.lstatSync(filename);
        return stats.isFile();
    }
    catch (err)
    {
        return false;
    }
}

function isDirectory(filename)
{
    try {
        var stats = fs.lstatSync(filename);
        return stats.isDirectory();
    }
    catch (err)
    {
        return false;
    }
}

function testDirectory(dirname, cb, options) {
    options = options || { };
    
    var filenames = fs.readdirSync(dirname);
    
    processFile();
    
    function processFile() {
        while (filenames.length) {
            var filename = filenames.shift();
            filename = path.join(dirname, filename);

            if (!isFile(filename))
                continue;
                
            if (path.extname(filename) !== '.js')
                continue;
                
            testFile(filename, function() {
                processFile();
            }, options);
            
            return;
        }
        
        cb(null, null);
    }
}

function testFile(filename, cb, options) {
    options = options || { };
    
    if (isDirectory(filename))
        return testDirectory(filename, cb, options);
        
    var file = require(path.resolve(filename));
    
    var fns = [];
    
    for (var n in file) {
        var fn = file[n];
        
        if (typeof fn != 'function')
            continue;
            
        fns.push({ name: n, fn: fn });
    }
    
    var counter = 50;
    var fntest;
    
    function doTest() {
        while (fns.length) {
            var fn = fns.shift();
            fntest = test();
        
            fn.fn(fntest);
            
            if (fntest.isAsync && !fntest.isDone) {
                setTimeout(doStep, 100);
                return;                
            }
        }
        
        if (options.verbose)
            console.log(path.basename(filename) + ': pass');
            
        cb(null, null);
    }    

    var doStep = function () {
        if (fntest.isDone) {
            doTest();
            return;
        }
        
        counter--;
        
        if (counter <= 0) {
            console.log(path.basename(filename) + ': error');
            cb('error', null);
            return;
        }
        
        setTimeout(doStep, 100);
    }
    
    doTest();
}

module.exports = {
    test: testFile
};

