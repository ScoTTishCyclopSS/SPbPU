{Тимушев 142гр}
Program P9_7;
uses crt;
type mas = array [1..10] of integer;
var C : mas;
    i,k: integer;          
begin
clrscr;
randomize;
for i:=1 to 10 do
C[i]:=random(31)-15;
for i:=1 to 10 do 
if C[i]<0 then 
k:=i;
for i:=1 to 10-1 do 
write(C[i]:4);
textcolor(Green);
write(C[k]:4);
textcolor();
for i:=k+1 to 10 do 
write(C[i]:4);
readLn;
end.

