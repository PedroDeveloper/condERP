using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace porrraaaaaaa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = true;
            boxBuscar.Enabled = true;
            bntDelete.Enabled = false;
            btnSave.Enabled = false;
            boxCpf.Enabled = false;
            boxVisitante.Enabled = false;
            boxAp.Enabled = false;
            boxBloco.Enabled = false;
            boxCpf.Text = "";
            boxVisitante.Text = "";
            boxAp.Text = "";
            boxBloco.Text = "";
        }

        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;User ID=pedrop1;Initial Catalog=condominio;Data Source=DESKTOP-135FB4B\SQLEXPRESS1";
        private string strSql = string.Empty;


        private void btnSave_Click(object sender, EventArgs e)
        {
            strSql = "insert into liberar_entrada (CPF,visitante,ap,bloco) values (@CPF, @visitante,@ap,@bloco)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CPF", SqlDbType.Int).Value = boxCpf.Text;
            comando.Parameters.Add("@visitante", SqlDbType.VarChar).Value = boxVisitante.Text;
            comando.Parameters.Add("@ap", SqlDbType.VarChar).Value = boxAp.Text;
            comando.Parameters.Add("@bloco", SqlDbType.VarChar).Value = boxBloco.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Visitante cadastrador");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            btnBuscar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = true;
            boxBuscar.Enabled = true;
            bntDelete.Enabled = false;
            btnSave.Enabled = true;
            boxCpf.Enabled = false;
            boxVisitante.Enabled = false;
            boxAp.Enabled = false;
            boxBloco.Enabled = false;
            boxCpf.Text = "";
            boxVisitante.Text = "";
            boxAp.Text = "";
            boxBloco.Text = "";

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            strSql = "select *from liberar_entrada  where CPF = @CPF";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CPF", SqlDbType.Int).Value = boxBuscar.Text;
     

            try
            {
                if (boxBuscar.Text == string.Empty)
                {
                    throw new Exception("Digite o CPF do morador");
                }
                sqlCon.Open();

                SqlDataReader dr = comando.ExecuteReader();

               
                if (dr.HasRows == false)
                {
                    throw new Exception(" CPF nao cadastrado");
                }

                dr.Read();
                boxCpf.Text = Convert.ToString(dr["CPF"]);
                boxVisitante.Text = Convert.ToString(dr["visitante"]);
                boxAp.Text = Convert.ToString(dr["ap"]);
                boxBloco.Text = Convert.ToString(dr["bloco"]);

                MessageBox.Show("liberado");

            }
            catch (Exception ex)
      
            {          MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            strSql = "update liberar_entrada set  CPF = @cpf,visitante = @visitante,ap= @ap,bloco = @bloco where CPF = @idBuscar";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@idBuscar", SqlDbType.Int).Value = boxBuscar.Text;

            comando.Parameters.Add("@CPF", SqlDbType.Int).Value = boxCpf.Text;
            comando.Parameters.Add("@visitante", SqlDbType.VarChar).Value = boxVisitante.Text;
            comando.Parameters.Add("@ap", SqlDbType.VarChar).Value = boxAp.Text;
            comando.Parameters.Add("@bloco", SqlDbType.VarChar).Value = boxBloco.Text;


            try
            {
              
                sqlCon.Open();                            
                comando.ExecuteNonQuery();
                MessageBox.Show("moficado");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void bntDelete_Click(object sender, EventArgs e)
        {

            strSql = "delete from liberar_entrada where  CPF = @idBuscar";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@idBuscar", SqlDbType.Int).Value = boxBuscar.Text;

    

            try
            {

                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Deletado");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = false;
            boxBuscar.Enabled = false;
            bntDelete.Enabled = false;
            btnSave.Enabled = true;
            boxCpf.Enabled = true;
            boxVisitante.Enabled = true;
            boxAp.Enabled = true;            
            boxBloco.Enabled = true;
            boxCpf.Text = "";
            boxVisitante.Text = "";
            boxAp.Text = "";
            boxBloco.Text = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = true;
            boxBuscar.Enabled = true;
            bntDelete.Enabled = false;
            btnSave.Enabled = true;
            boxCpf.Enabled = false;
            boxVisitante.Enabled = false;
            boxAp.Enabled = false;
            boxBloco.Enabled = false;
            boxCpf.Text = "";
            boxVisitante.Text = "";
            boxAp.Text = "";
            boxBloco.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
