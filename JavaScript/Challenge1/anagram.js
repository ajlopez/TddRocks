
function normalize(text) {
    var letters = [];
    
    for (n in text) {
        var letter = text[n];
        if (letter > ' ')
            letters.push(letter);
    }

    return letters.sort().join('')
};

var counts = {};

for (var k = 2; k < process.argv.length; k++) {
    var word = normalize(process.argv[k].toLowerCase());
    console.log(word);
    if (!counts[word])
        counts[word] = 0;
    counts[word]++;
}

var total = 0;

for (word in counts)
    if (counts[word] > 1)
        total += (counts[word]) * (counts[word] - 1) / 2;
        
console.log(total);

