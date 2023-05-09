package evidencia3;

public class GrafoTransporte {
    Nodo Inicio, Fin, aux;
    int CantidadElementos = 0;

    public GrafoTransporte() {
        Inicio = null;
        Fin = null;
    }

    public boolean Terminamos() {
        aux = Inicio;
        int Total = 0;
        while (aux != null) {
            Total = Total + aux.Oferta + aux.Demanda;
            aux = aux.Sig;
        }
        if (Total == 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean PreguntaSiRepite(int Costo[]) {
        for (int i = 0; i < Costo.length; i++) {
            if (aux.Costo == Costo[i]) {
                return true;
            }
        }
        return false;
    }

    public int BuscarCostoMenor(int CostoMenor, int CostoMayor, int Costo[]) {
        aux = Inicio;
        // Buscamos el menor de toda la lista
        for (int i = 0; aux != null; i++, aux = aux.Sig) {
            CostoMayor = aux.Costo;
            if (CostoMayor < CostoMenor && CostoMayor != 0 && PreguntaSiRepite(Costo) != true) {
                CostoMenor = CostoMayor;
            }
        }
        return CostoMenor;
    }

    public void ResolverProblema() {
        aux = Inicio;
        int CostoMenor, CostoMayor;
        int ValorTempCosto[] = new int[CantidadElementos];
        int ValorDemanda, ValorOferta, ValorY, ValorX;

        for (int i = 0; Terminamos() != true; i++) {
            aux = Inicio;
            CostoMenor = aux.Costo;
            CostoMayor = 0;
            int Min = BuscarCostoMenor(CostoMenor, CostoMayor, ValorTempCosto);
            aux = Inicio;
            while (Min != aux.Costo)
                aux = aux.Sig;
            if (aux.Oferta > aux.Demanda) {
                aux.Costo = aux.Demanda;
                aux.Oferta = aux.Oferta - aux.Demanda;
                aux.Demanda = aux.Demanda - aux.Costo;
                ValorDemanda = aux.Demanda;
                ValorOferta = aux.Oferta;
                ValorY = aux.Y;
                ValorX = aux.X;
                ValorTempCosto[i] = aux.Costo;
                EliminarLineaVertical(ValorY, ValorTempCosto);
                AcomodarDatos(ValorDemanda, ValorOferta, ValorX, ValorY, ValorTempCosto);
            } else if (aux.Oferta < aux.Demanda) {
                aux.Costo = aux.Oferta;
                aux.Demanda = aux.Demanda - aux.Oferta;
                aux.Oferta = aux.Costo - aux.Oferta;
                ValorDemanda = aux.Demanda;
                ValorOferta = aux.Oferta;
                ValorX = aux.X;
                ValorY = aux.Y;
                ValorTempCosto[i] = aux.Costo;
                EliminarLineaHorizontal(ValorTempCosto);
                AcomodarDatos(ValorDemanda, ValorOferta, ValorX, ValorY, ValorTempCosto);
            } else {
                // Si quedan valores iguales
                aux.Costo = aux.Oferta;
                aux.Demanda = aux.Demanda - aux.Costo;
                aux.Oferta = aux.Costo - aux.Oferta;
                ValorDemanda = aux.Demanda;
                ValorOferta = aux.Oferta;
                ValorX = aux.X;
                ValorY = aux.Y;
                ValorTempCosto[i] = aux.Costo;
                EliminarLineaHorizontal(ValorTempCosto);
                EliminarLineaVertical(ValorY, ValorTempCosto);
                AcomodarDatos(ValorDemanda, ValorOferta, ValorX, ValorY, ValorTempCosto);
            }
        }
    }

    public void AcomodarDatos(int ValorDemanda, int ValorOferta, int ValorX, int ValorY, int Costo[]) {
        aux = Inicio;
        // Aprovechamos para cambiar los valores de la columna oferta
        while (aux.X != ValorX)
            aux = aux.Sig;
        while (aux != null && aux.X == ValorX) {
            aux.Oferta = ValorOferta;
            aux = aux.Sig;
        }
        aux = Inicio;
        while (aux != null) {
            if (aux.Y == ValorY) {
                aux.Demanda = ValorDemanda;
            }
            aux = aux.Sig;
        }
    }

    public void EliminarLineaVertical(int ValorY, int Costo[]) {
        // Eliminamos la columna horizontal
        aux = Inicio;
        while (aux != null) {
            if (aux.Y == ValorY && PreguntaSiRepite(Costo) == false) {
                aux.Costo = 0;
            }
            aux = aux.Sig;
        }
    }

    public void EliminarLineaHorizontal(int Costo[]) {
        // Buscamos el inicio donde inicia el origen
        while (aux.Ant != null && aux.Origen == aux.Ant.Origen) {
            aux = aux.Ant;
        }
        // Una vez que lo encontramos debemos llenar con cero el costo de todos estos
        while (aux.Sig != null && aux.Origen == aux.Sig.Origen) {
            if (PreguntaSiRepite(Costo) == false)
                aux.Costo = 0;
            aux = aux.Sig;
        }
        if (aux.Sig != null && aux.Origen != aux.Sig.Origen && PreguntaSiRepite(Costo) == false)
            aux.Costo = 0;
    }

    public void AgregarLista(String VariableDecision, int X, int Y, String Origen, String Destino,
            int Costo, int Oferta, int Demanda) {
        if (Inicio == null) {
            Inicio = Fin = new Nodo(VariableDecision, X, Y, Origen, Destino, Costo, Oferta, Demanda);
            CantidadElementos++;
        } else {
            Fin.Sig = new Nodo(VariableDecision, X, Y, Origen, Destino, Costo, Oferta, Demanda);
            Fin.Sig.Ant = Fin;
            Fin = Fin.Sig;
            CantidadElementos++;
        }
    }

    public void ImprimeLista() {
        aux = Inicio;
        int Cont = 0;
        System.out.println(" ");
        System.out.println("/////////// |MTY|GDL|MON|SAL|");
        while (aux != null) {
            if (Cont == 0) {
                System.out.print(aux.Origen + " | " + aux.Costo);
            } else if (Cont < Math.sqrt(CantidadElementos)
            ) {
                System.out.print(" | " + aux.Costo);
            } else {
                System.out.print(" |\n" + aux.Origen + " | " + aux.Costo);
                Cont = 0;
            }
            Cont++;
            aux = aux.Sig;
        }
    }
}
