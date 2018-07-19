import { PortfolioModel } from '../models/PortfolioModel';
import { PortfolioItemModel } from '../models/PortfolioItemModel';

export const PORTFOLIOS: PortfolioModel[] = [
    { id: 1, title: 'Marco cryptos', icon: "", items: [
        { id: 1, title: "Neo", icon: "NEO", listPrice: 1, buyPrice: 2, sellPrice: 2 },
        { id: 1, title: "Nem", icon: "NEM", listPrice: 1, buyPrice: 2, sellPrice: 2 },
        { id: 1, title: "Icon", icon: "ICX", listPrice: 1, buyPrice: 2, sellPrice: 2 },
        { id: 1, title: "WaltonChain", icon: "WTC", listPrice: 1, buyPrice: 2, sellPrice: 2 },
        { id: 1, title: "Augur", icon: "REP", listPrice: 1, buyPrice: 2, sellPrice: 2 },
        { id: 1, title: "0x", icon: "ZRX", listPrice: 1, buyPrice: 2, sellPrice: 2 }
    ]}
];