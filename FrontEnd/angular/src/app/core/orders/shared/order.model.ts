import { Company } from "../../companies/shared/company.model";

export interface Order
{
    id: number;
    number: string;
    customer: Company;
}