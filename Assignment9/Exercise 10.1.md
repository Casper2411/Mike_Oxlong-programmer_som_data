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



• CAR
• SETCAR