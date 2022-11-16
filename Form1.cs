namespace DiccionariosLLneadoV2
{
    public partial class Form1 : Form
    {
        //Class1 ArchivoKey;
        //Class1 ArchivoWord;
        int counter = 0;
        string Word;
        int Subindice = 0;
        public Form1()
        {
            InitializeComponent();
            //ArchivoKey = new Class1();
           // ArchivoWord = new Class1();
        }

        private void btAdd_Click(object sender, EventArgs e)            // btAdd
        {
            //Limpia las celdas de los txt
            richTextBoxKey.Clear();
            richTextBoxWord.Clear();
            richTextBoxDictionary.Clear();
            richTextBoxDictionaryInverse.Clear();
            richTextBoxKeyList.Clear();
            richTextBoxWordList.Clear();
            lbRepeticiones.Items.Clear();
            lbmonitorWord.Items.Clear();
            repeticionesKey();
            repeticionesWord(); 
            escribirKey();
            escribirWord();
            leerKey();
            leerWord();
            tbKey.Clear();
            tbWord.Clear();
        }

        private void btClear_Click(object sender, EventArgs e)          // btClear
        {
            clearWork();
        }

        private void btShow_Click(object sender, EventArgs e)           //  btShow
        {
            clearWork();
            leerKey();
            leerWord();
            leerKeyList();
            leerWordList();
            showDic1();
            showDic2();
            repeticionesKey();
            repeticionesWord();
            
        }

        private void richTextBoxDictionary_TextChanged(object sender, EventArgs e)
        {

        }

        private void btRun_Click(object sender, EventArgs e)            // Bt Run
        {
            escribirKeyList();
            leerKeyList();
            escribirWordList();
            leerWordList();
            convertionToDictionaryKW();
            conversationToDictionaryInverse();
            showDic1();
            showDic2();
        }

        public void convertionToDictionaryKW()                  // Funcion diccionario Serial
        {
            // Conversion a diccionario y guadado en Dictionary.txt
            StreamReader conversionKWD = new StreamReader("Key.txt");
            string lineackwd;
            lineackwd = conversionKWD.ReadLine();

            StreamReader convertionKWD2 = new StreamReader("Word.txt");
            string lineackwd2;

            StreamWriter writeDictionary1 = new StreamWriter("Dictionary.txt");

            while (lineackwd != null)
            {
                lineackwd2 = convertionKWD2.ReadLine();
                writeDictionary1.WriteLine(tbName.Text + ".Add(" + c1.Text + lineackwd + c2.Text + ","+ c3.Text +lineackwd2 + c4.Text + ");");
                lineackwd = conversionKWD.ReadLine();
            }
            writeDictionary1.Close();
            convertionKWD2.Close();
            conversionKWD.Close();
        }

        public void conversationToDictionaryInverse()                 // Funcion Diccionario Inverso
        {
            // Conversion a diccionario y gradado en DictionaryInverse.txt
            StreamReader conversionKWD = new StreamReader("Key.txt");
            string lineackwd;
            lineackwd = conversionKWD.ReadLine();

            StreamReader convertionKWD2 = new StreamReader("Word.txt");
            string lineackwd2;

            StreamWriter writeDictionary1 = new StreamWriter("DictionaryInverse.txt");

            while (lineackwd != null)
            {
                lineackwd2 = convertionKWD2.ReadLine();
                writeDictionary1.WriteLine(tbName.Text + ".Add(" + c1.Text + lineackwd2 + c2.Text + "," + c3.Text + lineackwd + c4.Text + ");");
                lineackwd = conversionKWD.ReadLine();
            }
            writeDictionary1.Close();
            convertionKWD2.Close();
            conversionKWD.Close();
        }

        public void showDic1()                                        // Funcion mostrar Dic 1
        {
            //Lectura de Archivo Dictionary.txt
            StreamReader leerWord = new StreamReader("Dictionary.txt");
            string linea2;
            try
            {
                linea2 = leerWord.ReadLine();
                while (linea2 != null)
                {
                    richTextBoxDictionary.AppendText(linea2 + "\n");
                    linea2 = leerWord.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerWord.Close();
        }

        public void showDic2()                                       // Funcion mostrar Dic 2
        {
            //Lectura de Archivo DictionaryInverse.txt
            StreamReader leerWord = new StreamReader("DictionaryInverse.txt");
            string linea2;
            try
            {
                linea2 = leerWord.ReadLine();
                while (linea2 != null)
                {
                    richTextBoxDictionaryInverse.AppendText(linea2 + "\n");
                    linea2 = leerWord.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerWord.Close();
        }

        public void escribirKeyList()                               // Funcion escribir en KeyList.txt
        {
            // Conversion del Key.txt a lista y guardado en  KeyList.txt
            StreamReader conversionKey = new StreamReader("Key.txt");
            string lineack;

            lineack = conversionKey.ReadLine();

            while (lineack != null)
            {
                StreamWriter conversionKeyescribir = new StreamWriter("KeyList.txt", true);
                conversionKeyescribir.Write(c1.Text + lineack + c2.Text + ",");
                conversionKeyescribir.Close();
                lineack = conversionKey.ReadLine();
            }

            conversionKey.Close();
        }

        public void escribirWordList()                          // Funcion escribir en WordList.txt
        {
            // Conversion del Word.txt a lista y guardado en  WordList.txt
            StreamReader conversionWord = new StreamReader("Word.txt");
            string lineacw;

            lineacw = conversionWord.ReadLine();

            while (lineacw != null)
            {
                StreamWriter conversionWordescribir = new StreamWriter("WordList.txt", true);
                conversionWordescribir.Write(c3.Text + lineacw + c3.Text + ",");
                conversionWordescribir.Close();
                lineacw = conversionWord.ReadLine();
            }

            conversionWord.Close();
        }

        public void leerKeyList()                           //Funcion  Leer archivo KeyList.txt
        {
            // Leer archivo KeyList.txt
            StreamReader leerKeyList = new StreamReader("KeyList.txt");
            string lineakl;
            try
            {
                lineakl = leerKeyList.ReadLine();
                while (lineakl != null)
                {
                    richTextBoxKeyList.AppendText(lineakl);
                    lineakl = leerKeyList.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerKeyList.Close();
        }

        public void repeticionesKey()                           // Funcion obetener repeticiones de archivo Key.txt
        {
            //Lectura de Archivo Key.txt para comprobar repeticiones
            StreamReader leerKey3 = new StreamReader("Key.txt");
            string linea3;

            linea3 = leerKey3.ReadLine();

            while (linea3 != null)
            {
                StreamReader leerKey4 = new StreamReader("Key.txt");
                string linea4;

                linea4 = leerKey4.ReadLine();
                while (linea4 != null)
                {

                    if (linea4 == linea3)
                    {
                        counter = counter + 1;
                        Subindice = counter;
                        Word = linea4;
                    }

                    linea4 = leerKey4.ReadLine();
                }
                counter = 0;
                if (Subindice > 1)
                {
                    lbRepeticiones.Items.Add("The key " + Word + " is repeated " + Subindice + " times");
                }

                linea4 = leerKey4.ReadLine();
                leerKey4.Close();
                linea3 = leerKey3.ReadLine();
            }
            linea3 = leerKey3.ReadLine();
            leerKey3.Close();
        }

        public void repeticionesWord()                      // Obtiene las repeticiones del archivo Word.txt
        {
            //Lectura de Archivo Word.txt para comprobar repeticiones
            StreamReader leerWord3 = new StreamReader("Word.txt");
            string lineaW3;

            lineaW3 = leerWord3.ReadLine();

            while (lineaW3 != null)
            {
                StreamReader leerWord4 = new StreamReader("Word.txt");
                string lineaW4;

                lineaW4 = leerWord4.ReadLine();
                while (lineaW4 != null)
                {

                    if (lineaW4 == lineaW3)
                    {
                        counter = counter + 1;
                        Subindice = counter;
                        Word = lineaW4;
                    }

                    lineaW4 = leerWord4.ReadLine();
                }
                counter = 0;
                if (Subindice > 1)
                {
                    lbmonitorWord.Items.Add("The Word " + Word + " is repeated " + Subindice + " times");
                }

                lineaW4 = leerWord4.ReadLine();
                leerWord4.Close();
                lineaW3 = leerWord3.ReadLine();
            }
            lineaW3 = leerWord3.ReadLine();
            leerWord3.Close();

            
        }

        public void clearWork()             // Limpia los contenedores
        {
            tbKey.Clear();
            //tbName.Clear();
            tbWord.Clear();
            richTextBoxKey.Clear();
            richTextBoxWord.Clear();
            richTextBoxDictionary.Clear();
            richTextBoxDictionaryInverse.Clear();
            richTextBoxKeyList.Clear();
            richTextBoxWordList.Clear();
            lbRepeticiones.Items.Clear();
            lbmonitorWord.Items.Clear();
        }

        public void escribirKey()                   // Escribe en el Key.txt
        {
      
            //Escritura del Archivo Key.txt
            StreamWriter escribirKey = new StreamWriter("Key.txt", true);
            try
            {
                escribirKey.WriteLine(tbKey.Text);
            }
            catch
            {
                MessageBox.Show("¡Error! ಥ‿ಥ ");
            }
            escribirKey.Close();
        }

        public void escribirWord()                  // Escribe en el Word.txt
        {
            //Escritura del Archivo Word.txt
            StreamWriter escribirWord = new StreamWriter("Word.txt", true);
            try
            {
                escribirWord.WriteLine(tbWord.Text);
            }
            catch
            {
                MessageBox.Show("¡Error! ಥ‿ಥ ");
            }
            escribirWord.Close();
        }

        public void leerKey()
        {
            //Lectura de Archivo Key.txt
            StreamReader leerKey3 = new StreamReader("Key.txt");
            string linea3;
            try
            {
                linea3 = leerKey3.ReadLine();
                while (linea3 != null)
                {
                    richTextBoxKey.AppendText(linea3 + "\n");
                    linea3 = leerKey3.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerKey3.Close();

            
        }
        
        public void leerWord()
        {
            //Lectura de Archivo Word.txt
            StreamReader leerWordm = new StreamReader("Word.txt");
            string linea2m;
            try
            {
                linea2m = leerWordm.ReadLine();
                while (linea2m != null)
                {
                    richTextBoxWord.AppendText(linea2m + "\n");
                    linea2m = leerWordm.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerWordm.Close();
        }
         
        public void leerWordList()
        {
            // Leer archivo WordList.txt
            StreamReader leerWordList = new StreamReader("WordList.txt");
            string lineawl;
            try
            {
                lineawl = leerWordList.ReadLine();
                while (lineawl != null)
                {
                    richTextBoxWordList.AppendText(lineawl);
                    lineawl = leerWordList.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leerWordList.Close();
        }
    }
}