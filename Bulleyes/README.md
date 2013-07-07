# Bullseye

This TDD Kata is the solution to [Problem A - Bulleye](https://code.google.com/codejam/contest/2418487/dashboard)
from [Google Code Jam 2013](https://code.google.com/codejam), Round 1.

## Problem

Maria has been hired by the Ghastly Chemicals Junkies (GCJ) company to help them manufacture **bullseyes**. A **bullseye** consists of a number of concentric rings (rings that are centered at the same point), and it usually represents an archery target. GCJ is interested in manufacturing black-and-white bullseyes.

![Bulleye](https://code.google.com/codejam/contest/images/?image=bullseye.png&p=2464487&c=2418487)

Maria starts with **t** millilitres of black paint, which she will use to draw rings of thickness 1cm (one centimetre). A ring of thickness 1cm is the space between two concentric circles whose radii differ by 1cm.

Maria draws the first black ring around a white circle of radius **r** cm. Then she repeats the following process for as long as she has enough paint to do so:

- Maria imagines a white ring of thickness 1cm around the last black ring.
- Then she draws a new black ring of thickness 1cm around that white ring.

Note that each "white ring" is simply the space between two black rings.

The area of a disk with radius 1cm is **pi** cm2. 
One millilitre of paint is required to cover area **pi** cm2. 
What is the maximum number of black rings that Maria can draw? Please note that:

- Maria only draws complete rings. If the remaining paint is not enough to draw a complete black ring, she stops painting immediately.
- There will always be enough paint to draw at least one black ring.

## Input

The first line of the input gives the number of test cases, **T**. **T** test cases follow. Each test case consists of a line containing two space separated integers: **r** and **t**.

## Output

For each test case, output one line containing "Case **#x**: **y**", where **x** is the case number (starting from 1) and **y** is the maximum number of black rings that Maria can draw.

## Sample

```
Input  	
 
5
1 9
1 10
3 40
1 1000000000000000000
10000000000000000 1000000000000000000
```

```
Output 

Case #1: 1
Case #2: 2
Case #3: 3
Case #4: 707106780
Case #5: 49
```




