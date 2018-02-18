import { Component, OnInit } from '@angular/core';
import { PortfolioModel } from '../models/PortfolioModel';
import { PortfolioItemModel } from '../models/PortfolioItemModel';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.scss']
})
export class PortfolioComponent implements OnInit {

  portfolio: PortfolioModel = {
    id: 1,
    title: "Marco crypto's",
    icon: "",
    items: [
      { id: 1, title: "Neo", icon: "NEO", listPrice: 1, buyPrice: 2, sellPrice: 2 },
      { id: 1, title: "Nem", icon: "NEM", listPrice: 1, buyPrice: 2, sellPrice: 2 },
      { id: 1, title: "Icon", icon: "ICX", listPrice: 1, buyPrice: 2, sellPrice: 2 },
      { id: 1, title: "WaltonChain", icon: "WTC", listPrice: 1, buyPrice: 2, sellPrice: 2 },
      { id: 1, title: "Augur", icon: "REP", listPrice: 1, buyPrice: 2, sellPrice: 2 },
      { id: 1, title: "0x", icon: "ZRX", listPrice: 1, buyPrice: 2, sellPrice: 2 }
    ]
  };
  constructor() { }

  ngOnInit() {
  }

}
