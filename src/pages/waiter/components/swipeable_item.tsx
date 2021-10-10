import { Box, Center, Text } from "@chakra-ui/react";
import React from "react";

import {
  LeadingActions,
  SwipeableList,
  SwipeableListItem,
  SwipeAction,
  TrailingActions,
  Type as ListType,
} from "react-swipeable-list";
import "react-swipeable-list/dist/styles.css";
import { OrderModel } from "../../../models/order";

interface Props {
  children: React.ReactNode;
  swipeChild: React.ReactNode;
  icon: React.ReactNode;
  id: string;
  list: OrderModel[];
  onClick: (id: string) => void;
}

const SwipeableItem: React.FC<Props> = (props) => {
  const trailingActions = (id: string, onClick: (id: string) => void) => (
    <TrailingActions>
      <SwipeAction destructive={true} onClick={() => onClick(id)}>
        <Box bg="red.200">
          <Center justifyContent="justify-center" display="row" d="flex" px="1">
            {props.icon}
            {props.swipeChild}
          </Center>
        </Box>
      </SwipeAction>
    </TrailingActions>
  );

  return (
    <SwipeableList
      fullSwipe={false}
      style={{ backgroundColor: "orange.200" }}
      type={ListType.IOS}
      threshold={0.1}
    >
      <SwipeableListItem
        trailingActions={trailingActions(props.id, props.onClick)}
      >
        {props.list[0].title}
      </SwipeableListItem>
    </SwipeableList>
  );
};

export default SwipeableItem;
