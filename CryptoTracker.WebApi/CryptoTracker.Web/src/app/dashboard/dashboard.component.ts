import { Component, OnInit } from '@angular/core';
import { PortfolioService } from '../services/portfolio.service';
import { PortfolioModel } from '../models/PortfolioModel';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private portfolioService: PortfolioService) { }

  portfolios: PortfolioModel[];
  selectedPortfolio: PortfolioModel;

  ngOnInit() {
    
  }

  getPortfolios(): void{
    this.portfolioService.getPortfolios()
    .subscribe(portfolios => this.portfolios = portfolios);
  }

  getPortfolio(id: number): void{
    id = 1;
    this.portfolioService.getPortfolio(id)
    .subscribe(portfolio => this.selectedPortfolio = portfolio);
  }
}
