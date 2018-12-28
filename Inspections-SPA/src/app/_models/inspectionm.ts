import { BillToClient } from './billToClient';
import { Depot } from './depot';

export interface InspectionM {

    imInspectionRefNmbr: string;

    imInspectionDate: Date;

    imEquip1Id: string;

    // imTimeStamp: Date;

    imCleanInspection: string;

    billToClient: BillToClient;

    depot: Depot;
}


