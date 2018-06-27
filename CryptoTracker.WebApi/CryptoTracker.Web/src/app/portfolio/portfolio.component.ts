import { Component, OnInit } from '@angular/core';
import { PortfolioModel } from '../models/PortfolioModel';
import { PortfolioItemModel } from '../models/PortfolioItemModel';
import { PortfolioService } from '../portfolio.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.scss']
})
export class PortfolioComponent implements OnInit {

  portfolios: PortfolioModel[];
  
  constructor(private portfolioService: PortfolioService) { }

  ngOnInit() {
    this.getPortfolios();
  }

  getPortfolios(): void {
    this.portfolioService.getPortfolios().subscribe(portfolios => this.portfolios = portfolios);
    
  }
}
