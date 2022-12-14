      PROGRAM ASKEE

      USE ModuleDefs
      USE ModuleData

      IMPLICIT NONE
      !EXTERNAL STEMP_EPIC
C-----------------------------------------------------------------------
      CHARACTER*1   BLANK
      CHARACTER*6   ERRKEY
      CHARACTER*30  FILEIO
      
      REAL SRAD, SRFTEMP 
      REAL TAV, TAVG, TMAX, TMIN, XLAT
      REAL BIOMAS,DEPIR,MULCHMASS,SNOW
      REAL, DIMENSION(NL) :: ST, SW 
     
!     Variables that are sent out of STEMP_EPIC to preserve the value for next call 
!     (i.e., not needed by any outside routine)
      INTEGER :: NDays, WetDay(30)
      REAL :: CUMDPT, DSMID(NL), TDL, TMA(5), X2_PREV

      PARAMETER (ERRKEY = 'ASKEE ')      
      PARAMETER (BLANK  = ' ')

C     Define constructed variable types based on definitions in
C     ModuleDefs.for.

C     The variable "CONTROL" is of type "ControlType".
      TYPE (ControlType) CONTROL

C     The variable "ISWITCH" is of type "SwitchType".
      TYPE (SwitchType) ISWITCH
      
      TYPE (SoilType) SOILPROP
      
      TYPE (WeatherType) WEATHER
      

C*********************************************************************** 
C*********************************************************************** 
C     RUN INITIALIZATION
C***********************************************************************

      CONTROL % FILEIO  = FILEIO
      CONTROL % ERRCODE = 0
      CONTROL % DYNAMIC = 1
      CONTROL % RUN     = 1
      CONTROL % RNMODE  = 'B'
      CONTROL % YRDOY   = 2021100
      
      ISWITCH % ISWWAT = 'Y'
      
      SOILPROP % BD    = 1.6
      SOILPROP % DLAYR = 10.0
      SOILPROP % DS(1) = 10.0
      SOILPROP % DS(2) = 20.0 
      SOILPROP % DS(3) = 30.0 
      SOILPROP % DS(4) = 40.0 
      SOILPROP % DUL   = 0.3 
      SOILPROP % LL    = 0.2 
      SOILPROP % NLAYR = 4 
      SOILPROP % MSALB = 0.13
      
      
      
      SRAD    = 20.0 
      SW      = 0.2
      TAVG    = 25.0
      TMAX    = 30.0
      TMIN    = 20.0
      XLAT    = 28.0
      TAV     = 20.0
      !TAMP    = 10.0
      
      WEATHER % TAMP = 10.0
      WEATHER % RAIN = 0.0
      
      MULCHMASS = 0.0
      CALL PUT('ORGC' ,'MULCHMASS',MULCHMASS)   !kg/ha
      
      SNOW = 0.0
      CALL PUT('WATER','SNOW'     , SNOW)       !mm
      
      DEPIR = 0.0
      CALL PUT('MGMT','DEPIR',DEPIR)
      
      BIOMAS = 0.0
!     Soil cover function
      CALL PUT('PLANT','BIOMAS'   ,BIOMAS)      !kg/ha

C*********************************************************************** 
C*********************************************************************** 
C     CALL SOIL TEMPERATURE SUBROUTINE
C***********************************************************************
      DO WHILE (CONTROL % DYNAMIC .LE. SEASEND)
        
          CALL STEMP_EPIC(CONTROL, ISWITCH,  
     &    SOILPROP, SW, TAVG, TMAX, TMIN, TAV, WEATHER,       !Input
     &    SRFTEMP, ST,                                        !Output
!         These variables exported to retain value for next call 
     &    CUMDPT, DSMID, NDays, TDL, WetDay, TMA, X2_PREV)    

        CONTROL % DYNAMIC = CONTROL % DYNAMIC + 1
      ENDDO


      END PROGRAM ASKEE

!===========================================================================
! Variable listing
! ---------------------------------
! BLANK   Blank character 
! CONTROL Composite variable containing variables related to control and/or 
!           timing of simulation.  The structure of the variable 
!           (ControlType) is defined in ModuleDefs.for. 
!===========================================================================
