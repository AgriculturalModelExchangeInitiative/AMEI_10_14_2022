using System;
using System.Collections.Generic;
using System.Linq;
class STEMP_EPIC_Wrapper
{
    private STEMP_EPIC_State s;
    private STEMP_EPIC_State s1;
    private STEMP_EPIC_Rate r;
    private STEMP_EPIC_Auxiliary a;
    private STEMP_EPIC_Exogenous ex;
    private STEMP_EPIC_Component stemp_epic_Component;

    public STEMP_EPIC_Wrapper()
    {
        s = new STEMP_EPIC_State();
        r = new STEMP_EPIC_Rate();
        a = new STEMP_EPIC_Auxiliary();
        ex = new STEMP_EPIC_Exogenous();
        stemp_epic_Component = new STEMP_EPIC_Component();
        loadParameters();
    }

        double[] DS =  new double [100];
    string ISWWAT;
    double[] LL =  new double [100];
    double[] DLAYR =  new double [100];
    double[] BD =  new double [100];
    double[] SW =  new double [100];
    int NLAYR;
    int NL;
    double[] DUL =  new double [100];

    public double[] TMA{ get { return s.TMA;}} 
     
    public int NDays{ get { return s.NDays;}} 
     
    public int[] WetDay{ get { return s.WetDay;}} 
     
    public double TDL{ get { return s.TDL;}} 
     
    public double[] ST{ get { return s.ST;}} 
     
    public double X2_PREV{ get { return s.X2_PREV;}} 
     
    public double SRFTEMP{ get { return s.SRFTEMP;}} 
     

    public STEMP_EPIC_Wrapper(STEMP_EPIC_Wrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new STEMP_EPIC_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new STEMP_EPIC_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new STEMP_EPIC_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new STEMP_EPIC_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            stemp_epic_Component = (toCopy.stemp_epic_Component != null) ? new STEMP_EPIC_Component(toCopy.stemp_epic_Component) : null;
        }
    }

    public void Init(){
        stemp_epic_Component.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        stemp_epic_Component.DS = DS;
        stemp_epic_Component.ISWWAT = ISWWAT;
        stemp_epic_Component.LL = LL;
        stemp_epic_Component.DLAYR = DLAYR;
        stemp_epic_Component.BD = BD;
        stemp_epic_Component.SW = SW;
        stemp_epic_Component.NLAYR = NLAYR;
        stemp_epic_Component.NL = NL;
        stemp_epic_Component.DUL = DUL;
    }

    public void EstimateSTEMP_EPIC_(double TAVG, double TAV, double TMAX, double MULCHMASS, double SNOW, double BIOMAS, double DEPIR, double TMIN, double RAIN, double TAMP)
    {
        a.TAVG = TAVG;
        a.TAV = TAV;
        a.TMAX = TMAX;
        a.MULCHMASS = MULCHMASS;
        a.SNOW = SNOW;
        a.BIOMAS = BIOMAS;
        a.DEPIR = DEPIR;
        a.TMIN = TMIN;
        a.RAIN = RAIN;
        a.TAMP = TAMP;
        stemp_epic_Component.CalculateModel(s,s1, r, a, ex);
    }

}