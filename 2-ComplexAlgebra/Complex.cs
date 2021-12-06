using System;
namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class\
        private double _real;
        private double _imaginary;
        
        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }
        public double Real { get=>_real; }
        public double Imaginary { get=>_imaginary; }
        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        public double Phase => Math.Atan2(Imaginary, Real);
        public Complex Complement => new Complex(Real, -Imaginary);
        public Complex Sum(Complex add) => new Complex(Real + add.Real, Imaginary + add.Imaginary);
        public Complex Diff(Complex sub) => new Complex(Real - sub.Real, Imaginary - sub.Imaginary);
        public override string ToString() => Imaginary > 0 ? Real + " + " + Imaginary +"i" : Real + " " + Imaginary + "i";
        private bool Equals(Complex num) => (Real.Equals(num.Real) && Imaginary.Equals(num.Imaginary));
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return (this.Equals((Complex)obj));
        }
        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);
    }
}