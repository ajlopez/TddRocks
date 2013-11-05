function doFunction() {
    var counter = 0;
    var values = [1,2,3];

    doStep();
    
    function doStep() {
        doTest();
    }
    
    function doTest() {
        if (!values.length)
            return;
        
        console.log(values.shift());
        console.log('hi');
        counter++;
        console.log(counter);
        setTimeout(doTest, 1000);
    }    
}

module.exports = {
    test: doFunction
};
