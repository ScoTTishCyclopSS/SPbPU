{Тимушев 142гр}
Program P10_3;
uses crt;
type mas = array[1..9,1..9] of integer;
var 
    i,j,k:integer;
    D:array [1..9,1..9] of integer;
    C:array [1..9*9] of integer;
begin
randomize;
k:=0;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
D[i,j]:=random(9)+1;
write(D[i,j]:4);
if i mod 3 = 0 then
begin
inc(k);
C[k]:=D[i,j];
end;end;
writeln;
end;
writeln('C: ');    
for i:=1 to k do
write(C[i]:4);
readln;
end.