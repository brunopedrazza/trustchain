package org.hyperledger.fabric.samples.trustchain;

import java.util.ArrayList;
import java.util.List;

import org.hyperledger.fabric.contract.Context;
import org.hyperledger.fabric.contract.ContractInterface;
import org.hyperledger.fabric.contract.annotation.Contact;
import org.hyperledger.fabric.contract.annotation.Contract;
import org.hyperledger.fabric.contract.annotation.Default;
import org.hyperledger.fabric.contract.annotation.Info;
import org.hyperledger.fabric.contract.annotation.License;
import org.hyperledger.fabric.contract.annotation.Transaction;
import org.hyperledger.fabric.shim.ChaincodeException;
import org.hyperledger.fabric.shim.ChaincodeStub;
import org.hyperledger.fabric.shim.ledger.KeyValue;
import org.hyperledger.fabric.shim.ledger.QueryResultsIterator;

import com.owlike.genson.Genson;

@Contract(
        name = "basic",
        info = @Info(
                title = "Trustchain",
                description = "Contratos entre empresas com hyperledger",
                version = "0.0.1-SNAPSHOT",
                license = @License(
                        name = "Apache 2.0 License",
                        url = "http://www.apache.org/licenses/LICENSE-2.0.html")
                ))
@Default
public final class TrustChain2 implements ContractInterface {

    private final Genson genson = new Genson();

    private enum AssetTransferErrors {
        CONTRACT_NOT_FOUND,
        CONTRACT_ALREADY_EXISTS
    }

    /**
     * Creates some initial assets on the ledger.
     *
     * @param ctx the transaction context
     */
    @Transaction(intent = Transaction.TYPE.SUBMIT)
    public void InitLedger(final Context ctx) {
        ChaincodeStub stub = ctx.getStub();

        CreateContract(ctx, "asset1", "blue", 5, "Tomoko", 300);
        CreateContract(ctx, "asset2", "red", 5, "Brad", 400);
        CreateContract(ctx, "asset3", "green", 10, "Jin Soo", 500);
        CreateContract(ctx, "asset4", "yellow", 10, "Max", 600);
        CreateContract(ctx, "asset5", "black", 15, "Adrian", 700);
        CreateContract(ctx, "asset6", "white", 15, "Michel", 700);

    }

    /**
     * Creates a new asset on the ledger.
     *
     * @param ctx the transaction context
     * @param assetID the ID of the new asset
     * @param color the color of the new asset
     * @param size the size for the new asset
     * @param owner the owner of the new asset
     * @param appraisedValue the appraisedValue of the new asset
     * @return the created asset
     */
    @Transaction(intent = Transaction.TYPE.SUBMIT)
    public Properties CreateContract(final Context ctx, final String contractID, final String owner, final String hired,final String ownerCompany, final String hiredCompany, boolean jobDone, boolean jobApproved, final int value, final int conclusionDate) {
        ChaincodeStub stub = ctx.getStub();

        if (AssetExists(ctx, contractID)) {
            String errorMessage = String.format("%s already exists", contractID);
            System.out.println(errorMessage);
            throw new ChaincodeException(errorMessage, AssetTransferErrors.ASSET_ALREADY_EXISTS.toString());
        }

        Properties contract = new Properties(contractID, owner, hired, ownerCompany, hiredCompany, jobDone, jobApproved, value, conclusionDate);
        String contractJSON = genson.serialize(contract);
        stub.putStringState(contractID, contractJSON);

        return contract;
    }

    /**
     * Retrieves an asset with the specified ID from the ledger.
     *
     * @param ctx the transaction context
     * @param assetID the ID of the asset
     * @return the asset found on the ledger if there was one
     */
    @Transaction(intent = Transaction.TYPE.EVALUATE)
    public Properties ReadContract(final Context ctx, final String contractID) {
        ChaincodeStub stub = ctx.getStub();
        String contractJSON = stub.getStringState(contractID);

        if (contractJSON == null || contractJSON.isEmpty()) {
            String errorMessage = String.format("%s does not exist", contractID);
            System.out.println(errorMessage);
            throw new ChaincodeException(errorMessage, AssetTransferErrors.ASSET_NOT_FOUND.toString());
        }

        Properties contract = genson.deserialize(contractJSON, Properties.class);
        return contract;
    }

    /**
     * Updates the properties of an asset on the ledger.
     *
     * @param ctx the transaction context
     * @param assetID the ID of the asset being updated
     * @param color the color of the asset being updated
     * @param size the size of the asset being updated
     * @param owner the owner of the asset being updated
     * @param appraisedValue the appraisedValue of the asset being updated
     * @return the transferred asset
     */
    @Transaction(intent = Transaction.TYPE.SUBMIT)
    public Properties UpdateAsset(final Context ctx, final String contractID, final String owner, final String hired,final String ownerCompany, final String hiredCompany, boolean jobDone, boolean jobApproved, final int value, final int conclusionDate) {
        ChaincodeStub stub = ctx.getStub();

        if (!AssetExists(ctx, contractID)) {
            String errorMessage = String.format("%s does not exist", contractID);
            System.out.println(errorMessage);
            throw new ChaincodeException(errorMessage, AssetTransferErrors.ASSET_NOT_FOUND.toString());
        }

        Properties newcontract = new Properties(contractID, owner, hired, ownerCompany, hiredCompany, jobDone, jobApproved, value, conclusionDate);
        String newcontractJSON = genson.serialize(contract);
        stub.putStringState(contractID, newcontractJSON);

        return newcontract;
    }

    /**
     * Deletes asset on the ledger.
     *
     * @param ctx the transaction context
     * @param assetID the ID of the asset being deleted
     */
    @Transaction(intent = Transaction.TYPE.SUBMIT)
    public void DeleteAsset(final Context ctx, final String contractID) {
        ChaincodeStub stub = ctx.getStub();

        if (!AssetExists(ctx, contractID)) {
            String errorMessage = String.format("%s does not exist", contractID;
            System.out.println(errorMessage);
            throw new ChaincodeException(errorMessage, AssetTransferErrors.ASSET_NOT_FOUND.toString());
        }

        stub.delState(contractID);
    }

    /**
     * Checks the existence of the asset on the ledger
     *
     * @param ctx the transaction context
     * @param assetID the ID of the asset
     * @return boolean indicating the existence of the asset
     */
    @Transaction(intent = Transaction.TYPE.EVALUATE)
    public boolean AssetExists(final Context ctx, final String contractID) {
        ChaincodeStub stub = ctx.getStub();
        String contractJSON = stub.getStringState(contractID);

        return (contractJSON != null && !contractJSON.isEmpty());
    }

    /**
     * Retrieves all assets from the ledger.
     *
     * @param ctx the transaction context
     * @return array of assets found on the ledger
     */
    @Transaction(intent = Transaction.TYPE.EVALUATE)
    public String GetAllAssets(final Context ctx) {
        ChaincodeStub stub = ctx.getStub();

        List<Properties> queryResults = new ArrayList<Properties>();

        // To retrieve all assets from the ledger use getStateByRange with empty startKey & endKey.
        // Giving empty startKey & endKey is interpreted as all the keys from beginning to end.
        // As another example, if you use startKey = 'asset0', endKey = 'asset9' ,
        // then getStateByRange will retrieve asset with keys between asset0 (inclusive) and asset9 (exclusive) in lexical order.
        QueryResultsIterator<KeyValue> results = stub.getStateByRange("", "");

        for (KeyValue result: results) {
            Properties c = genson.deserialize(result.getStringValue(), Properties.class);
            queryResults.add(c);
            System.out.println(c.toString());
        }

        final String response = genson.serialize(queryResults);

        return response;
    }
}