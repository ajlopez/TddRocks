
var calc = require('../lib/calc.js');

exports["add two integer"] = function (test) {
    var result = calc.add(1, 2);
    test.equal(3, result);
}

exports["multiply two integer"] = function (test) {
    var result = calc.multiply(3, 2);
    test.equal(6, result);
}