import React, { useState, useEffect, useCallback, useMemo } from "react";
import { Link } from "react-router-dom";
import { Space, Button, Table, Popconfirm, message } from "antd";
import { axiosInstance } from "../../api/axios";

export const GenderList = ({}) => {
  const [genders, setGender] = useState([]);

  useEffect(() => {
    loadGenders();
  }, []);

  const loadGenders = async () => {
    const result = await axiosInstance.get("/Gender/GetGenders");
    setGender(result.data);
  };

  // const deleteGender = useCallback((genderId) => {
  //     DeleteGender(genderId).then(response => {
  //         loadGenders();
  //         message.success('Gender Deleted Successfully');
  //     })
  //     .catch((errorInfo) => {
  //         message.error(errorInfo);
  //     });
  // },[]);

  const columns = useMemo(
    () => [
      {
        title: "Gender Type",
        dataIndex: "genderType",
        key: "genderType",
      },
      // {
      //   title: "Action",
      //   key: "action",
      //   render: (text, record) => (
      //     <Space size="middle">
      //       <Button href={"/EditGender/" + record.genderId}>Edit</Button>
      //       <Popconfirm
      //         title="Are you sure to delete this record?"
      //         onConfirm={() => deleteGender(record.genderId)}
      //         okText="Yes"
      //         cancelText="No"
      //       >
      //         <Button>Delete</Button>
      //       </Popconfirm>
      //     </Space>
      //   ),
      // },
    ],
    []
  );

  return (
    <div>
      <h2 className="text-center">Gender List</h2>
      <div class>
        {/* <Link
          to={"AddGender"}
          type="button"
          className="flex flex-row justify-between items-center ml-2 px-1 border"
        >
          Create A New Gender
        </Link> */}
      </div>
      <br></br>
      <div className="rounded-lg" style={{ textAlign: "center" }}>
        <Table columns={columns} dataSource={genders} bordered />
      </div>
    </div>
  );
};
