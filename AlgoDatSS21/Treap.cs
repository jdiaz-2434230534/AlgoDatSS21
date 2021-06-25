using System;

namespace AlgoDatSS21
{
    class Treap : BinSearchTree
    {

        public override bool Insert(int x)
        {
            Node pointer = current; // Hilfsnode welche auf aktuelle Node verweist
            bool inserted = false;

            if (base.Search(x))
            {
                Console.WriteLine("Fehler: Das einzufügende Element ist bereits vorhanden.");
                return inserted; 
            }

            else
            {
                //Baum noch nicht vorhanden
                if (root == null)
                {
                    base.Insert(x);
                    root.Prio = ZufallsPrio(); //Zufällige Priorität vergeben

                    return true;
                }

                //Wenn Baumstruktur schon vorhanden, dann einfügen
                else
                {
                    base.Insert(x);
                    current.Prio = ZufallsPrio(); //Zufällige Priorität vergeben
                    inserted = true;
                }

                //Treap-Bedingung herstellen
                TreapBedingung(current);

                return inserted;
            }
        }

        // Hilfsfunktion zum Herstellen der Treapbedingung
        public void TreapBedingung(Node n)
        {
            //Baum leer?
            if (n != null)
            {
                while (n.Parent != null && n != null && n.Parent.Prio > n.Prio)     //While Eltern Priorität größer als Kind Priorität
                {
                    if (n.Element < n.Parent.Element)   //Prüfen ob Kind links oder rechts
                    {
                        // Rechts Rotation durchführen
                        RightRotation(n);
                    }
                    else
                    {
                        //Links Rotation durchführen
                        LeftRotation(n);
                    }
                }
            }
        }

        public override bool Delete(int x)
        {
            Node temp = null;
            bool deleted = false;

            //Element mit Suchfunktion finden und temp auf dieses setzen
            if (base.Search(x))
            {
                temp = current;
            }

            //Solange rotieren, bis zu löschendes Element ein Blatt ist
            while (temp.Left != null || temp.Right != null)
            {
                if (temp.Right == null || (temp.Left != null && temp.Left.Prio < temp.Right.Prio))
                    RightRotation(temp.Left);
                else
                    LeftRotation(temp.Right);
            }

            // Gesuchtes bzw. zu löschendes Element als Blatt löschen
            if (base.Delete(temp.Element))
            {
                deleted = true;
            }
            return deleted;
        }

        //Funktion zur Bestimmung der Priorität einer Node
        public int ZufallsPrio()
        {
            Random rnd = new Random();
            return rnd.Next(500);
        }

        protected void LeftRotation(Node node)
        {
            Node temp;

            if (node != null)
            {
                //Prüfen ob Elternelement Root ist
                if (node.Parent == root)
                {
                    temp = node.Left;               //rotierendes Element in temp zwischenspeichern
                    root = node;                    //mache node zur neuen Wurzel
                    root.Left = node.Parent;        //schiebe ursprüngliche Wurzel nach links-unten
                    node.Parent = null;             //Elternelement-Verknüpfung löschen
                    root.Left.Parent = root;        //Alter Wurzel die neue Wurzel als Elternelment zuweisen
                    root.Left.Right = temp;         //rotierende Node an neuer Stelle speichern

                    if (temp != null)
                    {
                        root.Left.Right.Parent = root.Left; //Neuen Elternknoten des rotierten Elements setzen
                    }
                }

                //Eltern Element ist nicht root
                else
                {
                    temp = node.Left;                   //rotierendes Element in temp zwischenspeichern
                    node.Left = node.Parent;            //Linkes Element nach oben verschieben
                    node.Parent = node.Parent.Parent;   //Parent-Element von node eine Ebene höher setzen

                    // Prüfen ob node zukünfig links oder rechts des "Eltern-Eltern"-Elements ist
                    if (node.Element < node.Parent.Element)
                    {
                        node.Parent.Left = node;
                    }

                    else
                    {
                        node.Parent.Right = node;
                    }

                    node.Left.Parent = node;    //node wird Elternelement vom verschobenen Element
                    node.Left.Right = temp;     //rotierende Node an neuer Stelle speichern
                    if (temp != null)
                    {
                        node.Left.Right.Parent = node.Left; //Neuen Elternknoten des rotierten Elements setzen
                    }
                }
            }
        }

        protected void RightRotation(Node node)
        {
            Node temp;

            if (node != null)
            {
                // Prüfen ob Elternelement Root ist
                if (node.Parent == root)
                {
                    temp = node.Right;              //rotierendes Element in temp zwischenspeichern
                    root = node;                    //mache node zur neuen Wurzel
                    root.Right = node.Parent;       //schiebe ursprüngliche Wurzel nach rechts-unten
                    node.Parent = null;             //Elternelement-Verknüpfung löschen
                    root.Right.Parent = root;       //Alter Wurzel die neue Wurzel als Elternelment zuweisen
                    root.Right.Left = temp;         //rotierende Node an neuer Stelle speichern

                    if (temp != null)
                    {
                        root.Right.Left.Parent = root.Right; //Neuen Elternknoten des rotierten Elements setzen
                    }
                }

                //Eltern Element ist nicht root
                else
                {
                    temp = node.Right;                  //rotierendes Element in temp zwischenspeichern
                    node.Right = node.Parent;           //Rechtes Element nach oben verschieben
                    node.Parent = node.Parent.Parent;   //Parent-Element von node eine Ebene höher setzen

                    // Prüfen ob node zukünfig links oder rechts des "Eltern-Eltern"-Elements ist
                    if (node.Element < node.Parent.Element)
                    {
                        node.Parent.Left = node;
                    }

                    else
                    {
                        node.Parent.Right = node;
                    }

                    node.Right.Parent = node;   //node wird Elternelement vom verschobenen Element
                    node.Right.Left = temp;     //rotierende Node an neuer Stelle speichern
                    if (temp != null)
                    {
                        node.Right.Left.Parent = node.Right; //Neuen Elternknoten des rotierten Elements setzen
                    }
                }
            }
        }
    }
}
