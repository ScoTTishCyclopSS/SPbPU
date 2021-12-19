 {Тимушев Федор 142гр}
var
y: byte;
x, D: real;  
begin
write('x = ');
readln(x);
if x > 0 then begin
D := 0;
for y := 1 to 5 do
D := D + y + cos(x)
end
else begin
D := 1;
for y := 2 to 10 do
D := D * (y - x)
end;
writeln('D = ', D:0:5);
readln
end.