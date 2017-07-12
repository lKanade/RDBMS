﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista {
    
    public partial class frmPrincipal:Form {

        List<Capa_Negocios.CargarColumnas> listColum = new List<Capa_Negocios.CargarColumnas> ();
        public frmPrincipal() {
            InitializeComponent ();
        }

        private void frmPrincipal_Load(object sender,EventArgs e) {
            cboDataBases.DisplayMember = "DATABASE_NAME";
            cboDataBases.ValueMember = "DATABASE_NAME";
            cboDataBases.DataSource = new Capa_Negocios.CargarBases ().DataBases ();
        }

        private void btnCargar_Click(object sender,EventArgs e) {
            DataTable objDT = new Capa_Negocios.CargarTablas ().Tablas (cboDataBases.SelectedValue.ToString ());
            lbTablas.ClearSelected ();
            if (objDT.Rows.Count > 0) {
                    lbTablas.DisplayMember = "TABLE_NAME";
                    lbTablas.ValueMember = "TABLE_NAME";
                    lbTablas.DataSource = objDT;
            } else {
                MessageBox.Show ("La base de datos selecciona no contiene tablas","Adverencia",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lbTablas.DataSource = objDT;
            }
        }

        private void lbTablas_DoubleClick(object sender,EventArgs e) {
            DataTable objDT = new Capa_Negocios.CargarColumnas ().datosColumnas (lbTablas.SelectedValue.ToString ());
            lbColumas.ClearSelected ();
            if (objDT.Rows.Count > 0) {
                lbColumas.DisplayMember = "COLUMN_NAME";
                lbColumas.ValueMember = "COLUMN_NAME";
                lbColumas.DataSource = objDT;
            } else {
                MessageBox.Show ("La tabla selecciona no contiene columas","Adverencia",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lbTablas.DataSource = objDT;
            }
        }

        private void lbColumas_DoubleClick(object sender,EventArgs e) {
            DataTable objDT = new Capa_Negocios.CargarEsquema ().Esquemas (lbColumas.SelectedValue.ToString ());
            if (objDT.Rows.Count > 0) {
                dgvInfoTablas.DataSource = objDT;
            }
        }
    }
}