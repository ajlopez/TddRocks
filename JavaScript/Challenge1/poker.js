
var values = "AKQJD98765432";
var escaleras = "AKQJD98765432A";

function isescalera(counts) {
    for (var k = 0; k + 4 < escaleras.length; k++) {
        count = 0;
        
        for (var j = 0; j < 5; j++)
            if (counts[escaleras[k + j]] == 1)
                count++;
                
        if (count == 5)
            return true;
    }
    
    return false;
}

function tocard(text) {
    return { value: text[0], type: text[1] };
}

function getcount(values, value) {
    var count = 0;
    for (var n in values)
        if (values[n] == value)
            count++;
            
    return count;
}

var cards = [];

for (var k = 2; k < process.argv.length; k++)
    cards.push(tocard(process.argv[k]));

var counts = { };
var types = { };

for (var n in cards) {
    var card = cards[n];
    
    if (!counts[card.value])
        counts[card.value] = 0;
        
    counts[card.value]++;
    
    if (!types[card.type])
        types[card.type] = 0;
        
    types[card.type]++;
}

if (getcount(counts, 4) == 1)
    console.log('poker');
else if (getcount(counts, 3) == 1 && getcount(counts, 2) == 1)
    console.log('full');
else if (getcount(counts, 3) == 1)
    console.log('pierna');
else if (getcount(counts, 2) == 2)
    console.log('doble par');
else if (getcount(counts, 2) == 1)
    console.log('par');
else if (getcount(types, 5)) {
    if (isescalera(counts))
        if (counts['A'] == 1 && counts['K'] == 1)
            console.log('escalera real');
        else
            console.log('escalera de color');
    else
        console.log('color');
}
else if (isescalera(counts))
    console.log('escalera');
else
    console.log('carta mas alta');
    