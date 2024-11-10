model Person
{   
    @key id: int32;
    
    name: string;
    
    @minValue(0)
    @maxValue(150)
    age: int32
    
}