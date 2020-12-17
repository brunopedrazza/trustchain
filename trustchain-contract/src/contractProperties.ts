/*
 * SPDX-License-Identifier: Apache-2.0
 */

import { Object, Property } from 'fabric-contract-api';
import { isatty } from 'tty';

@Object()
export class ContractProperties {

    @Property()
    private readonly contractID: string;
    
    @Property()
    private readonly owner: string;
    @Property()
    private readonly ownerCompany: string;
    
    @Property()
    private readonly hired: string;
    @Property()
    private readonly hiredCompany: string;
    
    @Property()
    private readonly value: number;
    @Property()
    private readonly conclusionDate: string;
    
    @Property()
    private jobApproved: boolean;
    @Property()
    private jobDone: boolean;

    get  ContractID(): string {
        return this.contractID;
    }
    get Owner(): string {
        return this.owner;
    }
    get OwnerCompany(): string {
        return this.ownerCompany;
    }
    get Hired(): string {
        return this.hired;
    }
    get HiredCompany(): string {
        return this.hiredCompany;
    }
    get Value(): number {
        return this.value;
    }
    get ConclusionDate(): string {
        return this.conclusionDate;
    }
    get JobApproved(): boolean {
        return this.jobApproved;
    }
    set JobApproved(isApproved: boolean) {
        this.jobApproved = isApproved;
    }
    get JobDone(): boolean {
        return this.jobDone;
    }
    set JobDone(isDone: boolean) {
        this.jobDone = isDone;
    }

    public constructor(contractId: string, owner: string, hired : string, ownerCompany: string, hiredCompany: string, jobDone: boolean, jobApproved: boolean, value: number, conclusionDate: string) {
        this.contractID = contractId;
        this.owner = owner;
        this.hired = hired;
        this.ownerCompany = ownerCompany;
        this.hiredCompany = hiredCompany;
        this.jobDone = jobDone;
        this.jobApproved = jobApproved;
        this.value = value;
        this.conclusionDate = conclusionDate;		
    }

}
