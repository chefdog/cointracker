import { Component, OnInit } from '@angular/core';
import { PORTFOLIOS } from '../mock-data/mock-portfolio';
import { PortfolioModel } from '../models/PortfolioModel';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  portfolios = PORTFOLIOS;
  selectedPortfolio: PortfolioModel;

  ngOnInit() {
    this.selectedPortfolio = this.portfolios[0];
  }

}
