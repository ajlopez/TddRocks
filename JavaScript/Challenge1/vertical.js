

var pos = 0;

var back = null;

while (true) {
    var text = "";
    
    for (var k = 2; k < process.argv.length; k++) {
        var word = process.argv[k];
        
        if (word[pos])
            text += word[pos];
        else
            text += ' ';
    }
    
    if (text.trim() == '')
        break;
    
    if (back)
        console.log(back);
        
    back = text;
    
    pos++;
}

while (back.length && back[back.length - 1] == ' ')
    back = back.substring(0, back.length - 1);

console.log(back);