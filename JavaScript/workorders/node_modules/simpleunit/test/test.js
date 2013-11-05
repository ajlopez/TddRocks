
var test = require('../lib/test'),
    assert = require('assert');

// create a test instance

var mytest = test();

assert.ok(mytest);
assert.equal(typeof mytest, "object");

// test ok

mytest.ok(1);
mytest.ok("foo");

// test equal

mytest.equal(1, 1);
mytest.equal('foo', 'foo');

