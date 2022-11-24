import { Component, OnInit } from '@angular/core';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
pdfMake.vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  createReport1(){
  

    const docDefinition: any =  {
      
      content: [
        {
          text: 'UbyTEC',
          fontSize: 20,
          alignment: 'center'
     
        },
        {
          text: 'Reporte consolidado de ventas',
          fontSize: 15,
          bold: true,
          alignment: 'center'
        
        },

      {text: 'Cliente:', style: 'subheader'},
      {
        
        table: {
          headerRows: 1,
          widths: ['auto', 'auto', 'auto', 'auto', 'auto'],
          body: [
            ['Afiliado', 'Compras', 'Conductor', 'Monto total','Monto servicio']
          ]
        },alignment: 'center'
      }]


    }
    const pdf = pdfMake.createPdf(docDefinition);
    pdf.open();
  }
  createReport2(){
  

    const docDefinition: any =  {
      
      content: [
        {
          text: 'UbyTEC',
          fontSize: 20,
          alignment: 'center'
     
        },
        {
          text: 'Reporte consolidado de ventas',
          fontSize: 15,
          bold: true,
          alignment: 'center'
        
        },

      {text: 'Cliente:', style: 'subheader'},
      {
        
        table: {
          headerRows: 1,
          widths: ['auto', 'auto', 'auto', 'auto'],
          body: [
            ['Afiliado', 'Compras', 'Monto total','Monto servicio']
          ]
        },alignment: 'center'
      }]


    }
    const pdf = pdfMake.createPdf(docDefinition);
    pdf.open();
  }
  }


