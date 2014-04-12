
var numbers = process.argv[2].split(',');

for (var k = 0; k < numbers.length; k++)
    numbers[k] = parseInt(numbers[k]);
    
var left = [];
var right = [];

var top = 0;

for (var k = 0; k < numbers.length; k++) {
    if (k && numbers[k] < numbers[k-1] && numbers[k-1] > top)
        top = numbers[k-1];
    left[k] = top;
}

top = 0;

for (var j = numbers.length - 1; j >= 0; j--) {
    if (j != numbers.length - 1 && numbers[j] < numbers[j+1] && numbers[j+1] > top)
        top = numbers[j+1];
    right[j] = top;    
}

var total = 0;

for (var k = 0; k < numbers.length; k++) {
    var min = Math.min(left[k], right[k]);
    
    if (min > numbers[k])
        total += min - numbers[k];
}

console.log(total);

