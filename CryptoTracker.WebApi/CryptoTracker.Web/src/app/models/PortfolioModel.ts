import { PortfolioItemModel } from './PortfolioItemModel';

export class PortfolioModel
{
    id: number;
    title: string;
    icon: string;
    items: PortfolioItemModel[];
}