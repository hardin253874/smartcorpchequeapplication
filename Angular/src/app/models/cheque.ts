export class cheque {
  chequeDate: Date;
  payee: string;
  amount: number;
  amountWord: string;
  constructor(
    fields?: {
      chequeDate?: Date;
      payee?: string;
      amount?: number;
      amountWord?: string;
    }) {
    if (fields) Object.assign(this, fields);
  }
}
