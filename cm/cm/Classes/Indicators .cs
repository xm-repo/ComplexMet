namespace cm
{
    public class Indicators
    {
        public Indicators(double Uab, double Ia, double Uc, double Ic, double Ib)
        {
            m_Uab = Uab;
            m_Ia = Ia;
            m_Uc = Uc;
            m_Ic = Ic;
            m_Ib = Ib;
        }

        public Indicators(Indicators other)
        {
            m_Uab = other.m_Uab;
            m_Ia = other.m_Ia;
            m_Uc = other.m_Uc;
            m_Ic = other.m_Ic;
            m_Ib = other.m_Ib;
        }
        public double m_Uab { get; set; }
        public double m_Ia { get; set; }
        public double m_Uc { get; set; }
        public double m_Ic { get; set; }
        public double m_Ib { get; set; }
    }
}
