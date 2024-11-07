# Exercise 10.1

## (i)

• ADD
Add takes the top two elements of the stack and adds them together. The way it does this is by taking the top element via the stackpointer and the stack. It first takes the s[sp-1] element and untags it, and then adds it with s[sp] which has also been untagged. After these are added together, the number is tagged again, and put on the stack at sp-1 . The reason for the untag of the two numbers, is to get the last bit away, that shows if it is a reference or int.
Then it decreases the stack pointer by one, and break.

• CSTI i
the array p, has the instructions in it, and when it encounters a CSTI instruction, it takes the next instruction from p by doing p[pc++], and then tagging it, and putting it on the stack on place sp+1 . Then the stack pointer is incremented, and then break.

• NIL
Sets the next position in the stack to 0, and then increases the sp by one, and then breaks.
If you push NIL, it will not be tagged, i.e. the program will know it is not the integer 0, but actually a reference to nothing. If you push CSTI 0, the value will be tagged, so it seems as 0 is a integer.

• IFZERO, which tests whether an integer is zero, or a reference is nil.
IfZERO starts by getting the top value of the stack and assigning it to v, and then decrements the sp value after, by using post-decrement oprator.
Then it creates an statement that calls IsInt on v, that checks if v is an integer, and if it is, then v is untagged, and compared to the number 0, which returns a boolean value. If v is not an int, then it compares v to zero, which also returns a boolean value. This statement is then part of an if-expression, that sets the value of pc, to either p[pc], if the value is zero, or increments the pc value with one, if it is not true.

• CONS
It starts by defining a reference to a word called p, and then giving it the length 2, and the stack and stack pointer. It then takes the sp-1 value of the stack and adds it to the p, and then does the same for the sp value of the stack. Then the value p is put at s[sp-1] and cast as int, and then the sp is decremented by one.

• CAR
This command gives the 1 word of a reference to a block on the stack. It does that by saving the top value of the stack, via sp, and casting it to word\* , and calling it p. Then it is checked if this value is null, then it would fail and print that it failed. If not failed, then it takes the first word of this block, by accesing p[1], and casting it to int, and overwriting the previous reference to the block, with this value. Then it breaks.

• SETCAR
Sets the first word of the block. It does this by first accessing the value of the top of the stack, and saving it as v, and then efter decrementing the sp value by one. Then the Block is accesed by getting the s[sp] value, and saving it to p.
After this p[1], i.e. the first word of the block, is set to the value of v. Then it breaks.

## (ii)


## (iii)
