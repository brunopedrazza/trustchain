package org.hyperledger.fabric.samples.trustchain;

import java.util.Objects;

import org.hyperledger.fabric.contract.annotation.DataType;
import org.hyperledger.fabric.contract.annotation.Property;

import com.owlike.genson.annotation.JsonProperty;

@DataType()
public final class Properties {

    @Property()
    private final String contractID;

    @Property()
    private final String owner;
	
	@Property()
    private final String hired;
	
	@Property()
    private final String ownerCompany;
	
	@Property()
    private final String hiredCompany;

    @Property()
    private boolean jobDone;
	
	@Property()
    private boolean jobApproved;

    @Property()
    private final int value;
	
	@Property()
    private final int conclusionDate;

    public String getContractID() {
        return contractID;
    }

    public String getOwner() {
        return owner;
    }
	
	public String getHired() {
        return hired;
    }
	
	public String getOwnerCompany() {
        return ownerCompany;
    }
	
	public String getHiredCompany() {
        return hiredCompany;
    }

    public boolean getJobDone() {
        return jobDone;
    }
	
	public void setJobDone(boolean b) {
        this.jobDone = b;
    }
	
	public boolean getJobApproved() {
        return jobApproved;
    }
	
	public void setJobApproved(boolean b) {
        this.jobApproved = b;
    }

    public int getValue() {
        return value;
    }
	
	public int getConclusionDate() {
        return conclusionDate;
    }
	
    public Properties(@JsonProperty("contractID") final String contractID, @JsonProperty("owner") final String owner, @JsonProperty("hired") final String hired,
            @JsonProperty("ownerCompany") final String ownerCompany, @JsonProperty("hiredCompany") final String hiredCompany, 
			@JsonProperty("jobDone") boolean jobDone, @JsonProperty("jobApproved") boolean jobApproved, @JsonProperty("value") final int value, 
            @JsonProperty("conclusionDate") final int conclusionDate) {
        this.contractID = contractID;
        this.owner = owner;
        this.hired = hired;
        this.owner = owner;
        this.ownerCompany = ownerCompany;
		this.hiredCompany = hiredCompany;
		this.jobDone = jobDone;
		this.jobApproved = jobApproved;
		this.value = value;
		this.conclusionDate = conclusionDate;		
    }

    @Override
    public boolean equals(final Object obj) {
        if (this == obj) {
            return true;
        }

        if ((obj == null) || (getClass() != obj.getClass())) {
            return false;
        }

        Asset other = (Properties) obj;

        return Objects.deepEquals(
                new String[] {getContractID(), getOwner(), getHired(), getOwnerCompany(), getHiredCompany()},
                new String[] {other.getContractID(), other.getOwner(), other.getHired(), other.getOwnerCompany(), other.getHiredCompany()})
                &&
                Objects.deepEquals(
                new int[] {getValue(), getConclusionDate()},
                new int[] {other.getValue(), other.getConclusionDate()})
				&&
                Objects.deepEquals(
				new boolean[] {getJobDone(), getJobApproved()},
                new boolean[] {other.getJobDone(), other.getJobApproved()});
    }

    @Override
    public int hashCode() {
        return Objects.hash(getContractID(), getOwner(), getHired(), getOwnerCompany(), getHiredCompany(), getJobDone(), getJobApproved(), getValue(), getConclusionDate());
    }

    @Override
    public String toString() {
        return this.getClass().getSimpleName() + "@" + Integer.toHexString(hashCode()) + " [contractID=" + contractID + ", owner="
                + owner + ", hired=" + hired + ", owner=" + owner + ", ownerCompany=" + ownerCompany + ", hiredCompany=" + hiredCompany + ", jobDone=" + jobDone + ", jobApproved=" + jobApproved + ", value=" + value + ", conclusionDate=" + conclusionDate + "]";
    }
}