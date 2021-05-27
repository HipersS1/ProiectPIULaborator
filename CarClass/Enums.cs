using System;


namespace CarClass
{

    //LABORATOR 4
    public enum CampuriAutoturism
    {
        MARCA = 0,
        MODEL = 1,
        ANFABRICATIE = 2,
        CAPACITATE_CILINDRICA = 3,
        PUTERE = 4,
        COMBUSTIBIL = 5,
        CUTIE_VITEZE = 6,
        CAROSERIE = 7,
        CULOARE = 8,
        PRET = 9,
        NUME_VANZATOR = 10,
        PRENUME_VANZATOR = 11,
        NUME_CUMPARATOR = 12,
        PRENUME_CUMPARATOR = 13,
        DATA_TRANZACTIE = 14,
        OPTIUNI = 15
    };
    public enum TipCaroserie
    {
        CABRIO = 1,
        BERLINA = 2,
        COUPE = 3,
        PICKUP = 4,
        HATCHBACK = 5,
        BREAK = 6,
        OFF_ROAD = 7,
        MINIBUS = 8,
        MONOVOLUM = 9,
        SUV = 10
    };

    public enum Culori
    {
        NEGRU = 1,
        ALB = 2,
        GRI = 3,
        ROSU = 4,
        ALBASTRU = 5,
        VERDE = 6,
        GALBEN = 7,
        PORTOCALIU = 8,
        MOV = 9,
    };

    public enum TipCombustibil
    {
        BENZINA = 1,
        DIESEL = 2,
        GPL = 3,
        HIBRID = 4,
        ELECTRIC = 5,
        BENZINA_GPL = 6,
    };

    public enum TipCutie
    {
        MANUALA = 1,
        AUTOMATA = 2,
    };
}