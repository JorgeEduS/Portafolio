package evidencia3;

public class Nodo {
    public String VariableDecision;
    public int X;
    public int Y;
    public String Origen;
    public String Destino;
    public int Costo;
    public int Oferta;
    public int Demanda;
    Nodo Sig, Ant;

    public Nodo(String VariableDecision, int X, int Y, String Origen, String Destino, int Costo, 
    int Oferta, int Demanda){
        this.VariableDecision = VariableDecision;
        this.X = X;
        this.Y = Y;
        this.Origen = Origen;
        this.Destino = Destino;
        this.Costo = Costo;
        this.Oferta = Oferta;
        this.Demanda = Demanda;
        Sig = null;
        Ant = null;
    }
}
