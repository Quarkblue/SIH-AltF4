import mongoose from "mongoose";

const userSchema = mongoose.Schema({
    phone:Number,
    query:String
})
const userq = mongoose.model("userq",userSchema)
export default userq;