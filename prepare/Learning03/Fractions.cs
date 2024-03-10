using System;

public class Fraction{
    private int _top;
    private int _bottom;

    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber){
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }

    public int GetTop(){
        Console.Write("What is the numerator? ");
        int top = int.Parse(Console.ReadLine());
        return top;
    }
    public int GetBottom(){
        Console.Write("what is the denominator? ");
        int bottom = int.Parse(Console.ReadLine());
        return bottom;
    }
    public void SetTop(int top){
        _top = top;
    }
    public void SetBottom(int bottom){
        _bottom = bottom;
    }
    public string GetFractionString(){
        string fraction = $"{_top}/{_bottom}";
        return fraction;
    }
    public double GetDecimalValue(){
        return (double)_top / (double)_bottom;
    }
}