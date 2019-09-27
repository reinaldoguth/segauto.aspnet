using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace SegAuto_CRUD_MySQL
{
    public partial class index : System.Web.UI.Page
    {
        string connectionString = @"Server=rwplus.com.br;Database=rwplusco_segauto;Uid=rwplusco_segauto;Pwd=.segauto@;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
                {
                    sqlConn.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("RegInsertOrUpdate", sqlConn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_tb10_id", Convert.ToInt32(hfApoliceID.Value == "" ? "0" : hfApoliceID.Value));
                    sqlCmd.Parameters.AddWithValue("_tb10_nr", txtNrApolice.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_tb10_cpfcnpj", txtDocSegurado.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_tb10_placa", txtPlacaVeiculo.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_tb10_valor_premio", Convert.ToDecimal(txtValorPremio.Text.Trim()));
                    sqlCmd.ExecuteNonQuery();
                    GridFill();
                    Clear();
                    lblSuccessMessage.Text = "Registro gravado com sucesso.";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        void Clear()
        {
            hfApoliceID.Value = "";
            txtNrApolice.Text = 
                txtDocSegurado.Text = 
                txtPlacaVeiculo.Text = 
                txtValorPremio.Text = "";
            btnSave.Text = "Salvar";
            btnDelete.Enabled = false;
            lblErrorMessage.Text = 
                lblSuccessMessage.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void GridFill()
        {
            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("RegViewAll", sqlConn);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvApolices.DataSource = dtbl;
                gvApolices.DataBind();
            }
        }

        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
//            int regID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int regID = int.Parse((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("RegViewById", sqlConn);
                sqlDa.SelectCommand.Parameters.AddWithValue("_tb10_id", regID);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                txtNrApolice.Text = dtbl.Rows[0][1].ToString();
                txtDocSegurado.Text = dtbl.Rows[0][2].ToString();
                txtPlacaVeiculo.Text = dtbl.Rows[0][3].ToString();
                txtValorPremio.Text = dtbl.Rows[0][4].ToString();

                hfApoliceID.Value = dtbl.Rows[0][0].ToString();

                btnSave.Text = "Atualizar";
                btnDelete.Enabled = true;            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("RegDeleteById", sqlConn);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("_tb10_id", Convert.ToInt32(hfApoliceID.Value == "" ? "0" : hfApoliceID.Value));
                sqlCmd.ExecuteNonQuery();
                GridFill();
                Clear();
                lblSuccessMessage.Text = "Registro apagado com sucesso.";
            }
        }
    }
}