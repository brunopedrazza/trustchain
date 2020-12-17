/*
 * SPDX-License-Identifier: Apache-2.0
 */

import { Context, Contract, Info, Returns, Transaction } from 'fabric-contract-api';
import { ContractProperties } from './contractProperties';

enum AssetTransferErrors {
    CONTRACT_NOT_FOUND,
    CONTRACT_ALREADY_EXISTS
}

@Info({title: 'trustchain', description: 'My trustchain Contract' })
export class ContractController extends Contract {
    
    /**
     * 
     * @param ctx 
     * @param contractID 
     */
    @Transaction(false)
    @Returns('boolean')
    public async contractExists(ctx: Context, contractID: string): Promise<boolean> {
        const buffer = await ctx.stub.getState(contractID);
        return (!!buffer && buffer.length > 0);
    }

    /**
     * Creates a new contract on the ledger.
     *
     * @param ctx the transaction context
     * @param contractID the ID of the new contract
     * @param owner 
     * @param hired 
     * @param ownerCompany 
     * @param hiredCompany 
     * @param jobDone
     * @param jobApproved
     * @param value
     * @param conclusionDate
     * @returns the created contract
     */
    @Transaction()
    @Returns('ContractProperties')
    public async CreateContract(ctx: Context, contractID: string, owner: string, hired: string, ownerCompany: string, hiredCompany: string, jobDone : boolean, jobApproved: boolean, value : number, conclusionDate: string) : Promise<ContractProperties> {
        const exists = await this.contractExists(ctx, contractID);
        if (exists) {
            console.log(`The contract ${contractID} already exists`)
            throw new Error(`The contract ${contractID} already exists`);
        }

        const contract = new ContractProperties(contractID, owner, hired, ownerCompany, hiredCompany, jobDone, jobApproved, value, conclusionDate);
        const buffer = Buffer.from(JSON.stringify(contract));
        await ctx.stub.putState(contractID, buffer);

        return contract;
    }

    /**
    * Reads the value of a stored contract
    * @param ctx
    * @param contractID
    * @returns the contract object if the ID exist
    */
    @Transaction(false)
    @Returns('ContractProperties')
    public async readContract(ctx: Context, contractID: string): Promise<ContractProperties> {
        const exists = await this.contractExists(ctx, contractID);
        if (!exists) {
            console.log(`The contract ${contractID} does not exist`)
            throw new Error(`The contract ${contractID} does not exist`);
        }
        const buffer = await ctx.stub.getState(contractID);
        const contract = JSON.parse(buffer.toString()) as ContractProperties;
        return contract;
    }

    /**
     * 
     * @param ctx 
     * @param contractID 
     * @param owner 
     * @param hired 
     * @param ownerCompany 
     * @param hiredCompany 
     * @param jobDone 
     * @param jobApproved 
     * @param value 
     * @param conclusionDate 
     */
    @Transaction()
    @Returns("ContractProperties")
    public async updateContract(ctx: Context, contractID: string, owner: string, hired: string, ownerCompany: string, hiredCompany: string, jobDone : boolean, jobApproved: boolean, value : number, conclusionDate: string): Promise<ContractProperties> {
        const exists = await this.contractExists(ctx, contractID);
        if (!exists) {
            console.log(`The contract ${contractID} does not exist`)
            throw new Error(`The contract ${contractID} does not exist`);
        }
        const contract = new ContractProperties(contractID, owner, hired, ownerCompany, hiredCompany, jobDone, jobApproved, value, conclusionDate);
        const buffer = Buffer.from(JSON.stringify(contract));
        await ctx.stub.putState(contractID, buffer);
        return contract;
    }

    /**
    * 
    * @param ctx 
    * @param contractID 
    */
    @Transaction()
    public async deleteContract(ctx: Context, contractID: string): Promise<void> {
        const exists = await this.contractExists(ctx, contractID);
        if (!exists) {
            console.log(`The contract ${contractID} does not exist`);
            throw new Error(`The contract ${contractID} does not exist`);
        }
        await ctx.stub.deleteState(contractID);
    }

    /**
     * 
     * @param ctx 
     */
   @Transaction()
   @Returns('Array<ContractProperties>')
   public async getAllContracts(ctx: Context): Promise<Array<ContractProperties>> {
        const contracts = new Array<ContractProperties>();
        const iterator = await ctx.stub.getStateByRange('', '');
        while (true) {
            const res = await iterator.next();
            if (res.value) {
                const contract = JSON.parse(res.value.value.toString()) as ContractProperties;
                contracts.push(contract);
            }
            if (res.done) {
                await iterator.close();
                break;
            }
        }
        return contracts;
   }


    /**
     * Creates some initial assets on the ledger.
     *
     * @param ctx the transaction context
     */
    @Transaction()
    public async InitLedger(ctx: Context) : Promise<void> {
        await this.CreateContract(ctx, '1', 'Joao', 'Jose', 'Company A', 'Company B', false, false, 150, '2019-01-02');
        await this.CreateContract(ctx, '2', 'Joao', 'Caio', 'Company A', 'Company C', false, true, 150, '2019-06-05');
        await this.CreateContract(ctx, '3', 'Jose', 'Joao', 'Company B', 'Company A', true, true, 150, '2019-12-01');
        await this.CreateContract(ctx, '4', 'Jose', 'Miguel', 'Company B', 'Company D', true, true, 150, '2020-01-06');
        await this.CreateContract(ctx, '5', 'Caio', 'Miguel', 'Company C', 'Company D', false, false, 150, '2020-07-25');
        await this.CreateContract(ctx, '6', 'Miguel', 'Joao', 'Company D', 'Company A', false, true, 150, '2020-03-24');
    }
}
