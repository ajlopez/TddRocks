
var assert = require('assert');
var calc = require('../lib/calc.js');

assert.equal(calc.add(1, 2), 3);
assert.equal(calc.add(-3, -5), -8);

assert.equal(calc.multiply(3, 2), 6);
assert.equal(calc.multiply(4, -2), -8);
