function fibo(n) { if (n == 0) return 0; if (n == 1) return 1; return fibo(n-2) + fibo(n-1); } var n = parseInt(process.argv[2]); console.log(fibo(n)); 
