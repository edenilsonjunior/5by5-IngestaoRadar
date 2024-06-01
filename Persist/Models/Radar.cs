namespace Models
{
    internal class Radar
    {
        public string ConcessionaryCompany{ get; } // "concessionaria"

        public int YearPvnSvn{get;} // "ano_do_pnv_snv":

        public string RadarType{get;} // "tipo_de_radar"

        public string Highway{get;} // "rodovia"

        public string State{get;} // "uf"

        public string KmM{get;} // "km_m"

        public string City{get;} //  "municipio"

        public string LaneType{get;} // "tipo_pista"

        public string Direction{get;} // "sentido"

        public string Situation{get;} // "situacao"

        public List<DateOnly> InactivationDateList{get;} // "data_da_inativacao": []

        public double Latitude{get;} // "latitude"

        public double Longitude{get;} // "longitude"

        public int LightSpeed{get;} // "velocidade_leve"

    }
}
