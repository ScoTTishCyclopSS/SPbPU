   {“имушев 142гр}
program P2_1;
uses crt;
var
    a,a_0:real;
begin
   write('¬ведите a: ');
   readln(a_0);
    a := a_0;
    a := a*a;
    a := a*a*a;
    a := a*a*a;
    a := a * a_0;
   writeln('a^19 = ', a)
end.
